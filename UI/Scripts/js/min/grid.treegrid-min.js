/*
 * jqGrid extension - Tree Grid
 * Tony Tomov tony@trirand.com
 * http://trirand.com/blog/ 
 */
;(function(c){c.fn.extend({setTreeNode:function(j,h){return this.each(function(){var b=this;if(!b.grid||!b.p.treeGrid){return}var f=0,g=0;if(!b.p.expColInd){for(var i in b.p.colModel){if(b.p.colModel[i].name==b.p.ExpandColumn){f=g;b.p.expColInd=f;break}g++}if(!b.p.expColInd){b.p.expColInd=f}}else{f=b.p.expColInd}var k=b.p.treeReader.expanded_field;var l=b.p.treeReader.leaf_field;var r=b.p.treeReader.level_field;h.level=j[r];if(b.p.treeGridModel=='nested'){h.lft=j[b.p.treeReader.left_field];h.rgt=j[b.p.treeReader.right_field];if(!j[l]){j[l]=(parseInt(h.rgt,10)===parseInt(h.lft,10)+1)?'true':'false'}}else{h.parent_id=j[b.p.treeReader.parent_id_field]}var u=(j[k]&&j[k]=="true")?true:false;var n=parseInt(h.level,10);var o,p;if(b.p.tree_root_level===0){o=n+1;p=n}else{o=n;p=n-1}var q=document.createElement("div");c(q).addClass("tree-wrap").width(o*18);var m=document.createElement("div");c(m).css("left",p*18);q.appendChild(m);if(j[l]=="true"){c(m).addClass("tree-leaf");h.isLeaf=true}else{if(j[k]=="true"){c(m).addClass("tree-minus treeclick");h.expanded=true}else{c(m).addClass("tree-plus treeclick");h.expanded=false}}if(parseInt(j[r],10)!==parseInt(b.p.tree_root_level,10)){if(!c(b).isVisibleNode(h)){c(h).css("display","none")}}var t=c("td:eq("+f+")",h).html();var s=c("td:eq("+f+")",h).html("<span>"+t+"</span>").prepend(q);c(".treeclick",s).click(function(a){var d=a.target||a.srcElement;var e=c(d,b.rows).parents("tr:first")[0].rowIndex;if(!b.rows[e].isLeaf){if(b.rows[e].expanded){c(b).collapseRow(b.rows[e]);c(b).collapseNode(b.rows[e])}else{c(b).expandRow(b.rows[e]);c(b).expandNode(b.rows[e])}}return false});c("span",s).css("cursor","pointer").click(function(a){var d=a.target||a.srcElement;var e=c(d,b.rows).parents("tr:first")[0].rowIndex;if(!b.rows[e].isLeaf){if(b.rows[e].expanded){c(b).collapseRow(b.rows[e]);c(b).collapseNode(b.rows[e])}else{c(b).expandRow(b.rows[e]);c(b).expandNode(b.rows[e])}}c(b).setSelection(b.rows[e].id);return false})})},setTreeGrid:function(){return this.each(function(){var a=this;if(!a.p.treeGrid){return}c.extend(a.p,{treeANode:0,treedatatype:null});if(a.p.treeGridModel=='nested'){a.p.treeReader=c.extend({level_field:"level",left_field:"lft",right_field:"rgt",leaf_field:"isLeaf",expanded_field:"expanded"},a.p.treeReader)}else if(a.p.treeGridModel=='adjacency'){a.p.treeReader=c.extend({level_field:"level",parent_id_field:"parent",leaf_field:"isLeaf",expanded_field:"expanded"},a.p.treeReader)}})},expandRow:function(b){this.each(function(){var d=this;if(!d.grid||!d.p.treeGrid){return}var e=c(d).getNodeChildren(b);c(e).each(function(a){c(this).css("display","");if(this.expanded){c(d).expandRow(this)}})})},collapseRow:function(b){this.each(function(){var d=this;if(!d.grid||!d.p.treeGrid){return}var e=c(d).getNodeChildren(b);c(e).each(function(a){c(this).css("display","none");c(d).collapseRow(this)})})},getRootNodes:function(){var f=[];this.each(function(){var d=this;if(!d.grid||!d.p.treeGrid){return}switch(d.p.treeGridModel){case'nested':var e=d.p.treeReader.level_field;c(d.rows).each(function(a){if(parseInt(this[e],10)===parseInt(d.p.tree_root_level,10)){f.push(this)}});break;case'adjacency':var b=d.p.treeReader.parent_id_field;c(d.rows).each(function(a){if(this[b]==null){f.push(this)}});break}});return f},getNodeDepth:function(d){var e=null;this.each(function(){var a=this;if(!this.grid||!this.p.treeGrid){return}switch(a.p.treeGridModel){case'nested':e=parseInt(d.level,10)-parseInt(this.p.tree_root_level,10);break;case'adjacency':e=c(a).getNodeAncestors(d);break}});return e},getNodeParent:function(f){var g=null;this.each(function(){var a=this;if(!a.grid||!a.p.treeGrid){return}switch(a.p.treeGridModel){case'nested':var d=parseInt(f.lft,10),e=parseInt(f.rgt,10),b=parseInt(f.level,10);c(this.rows).each(function(){if(parseInt(this.level,10)===b-1&&parseInt(this.lft)<d&&parseInt(this.rgt)>e){g=this;return false}});break;case'adjacency':c(this.rows).each(function(){if(this.id===f.parent_id){g=this;return false}});break}});return g},getNodeChildren:function(i){var k=[];this.each(function(){var d=this;if(!d.grid||!d.p.treeGrid){return}switch(d.p.treeGridModel){case'nested':var e=parseInt(i.lft,10),b=parseInt(i.rgt,10),f=parseInt(i.level,10);var g=i.rowIndex;c(this.rows).slice(1).each(function(a){if(parseInt(this.level,10)===f+1&&parseInt(this.lft,10)>e&&parseInt(this.rgt,10)<b){k.push(this)}});break;case'adjacency':c(this.rows).slice(1).each(function(a){if(this.parent_id==i.id){k.push(this)}});break}});return k},getNodeAncestors:function(d){var e=[];this.each(function(){if(!this.grid||!this.p.treeGrid){return}var a=c(this).getNodeParent(d);while(a){e.push(a);a=c(this).getNodeParent(a)}});return e},isVisibleNode:function(e){var b=true;this.each(function(){var a=this;if(!a.grid||!a.p.treeGrid){return}var d=c(a).getNodeAncestors(e);c(d).each(function(){b=b&&this.expanded;if(!b){return false}})});return b},isNodeLoaded:function(d){var e;this.each(function(){var a=this;if(!a.grid||!a.p.treeGrid){return}if(d.loaded!==undefined){e=d.loaded}else if(d.isLeaf||c(a).getNodeChildren(d).length>0){e=true}else{e=false}});return e},expandNode:function(a){return this.each(function(){if(!this.grid||!this.p.treeGrid){return}if(!a.expanded){if(c(this).isNodeLoaded(a)){a.expanded=true;c("div.treeclick",a).removeClass("tree-plus").addClass("tree-minus")}else{a.expanded=true;c("div.treeclick",a).removeClass("tree-plus").addClass("tree-minus");this.p.treeANode=a.rowIndex;this.p.datatype=this.p.treedatatype;if(this.p.treeGridModel=='nested'){c(this).setGridParam({postData:{nodeid:a.id,n_left:a.lft,n_right:a.rgt,n_level:a.level}})}else{c(this).setGridParam({postData:{nodeid:a.id,parentid:a.parent_id,n_level:a.level}})}c(this).trigger("reloadGrid");this.treeANode=0;if(this.p.treeGridModel=='nested'){c(this).setGridParam({postData:{nodeid:'',n_left:'',n_right:'',n_level:''}})}else{c(this).setGridParam({postData:{nodeid:'',parentid:'',n_level:''}})}}}})},collapseNode:function(a){return this.each(function(){if(!this.grid||!this.p.treeGrid){return}if(a.expanded){a.expanded=false;c("div.treeclick",a).removeClass("tree-minus").addClass("tree-plus")}})},SortTree:function(l){return this.each(function(){if(!this.grid||!this.p.treeGrid){return}var e,b,f,g=[],i=c(this).getRootNodes();i.sort(function(a,d){if(a.sortKey<d.sortKey){return-l}if(a.sortKey>d.sortKey){return l}return 0});for(e=0,b=i.length;e<b;e++){f=i[e];g.push(f);c(this).collectChildrenSortTree(g,f,l)}var k=this;c.each(g,function(a,d){c('tbody',k.grid.bDiv).append(d);d.sortKey=null})})},collectChildrenSortTree:function(i,k,l){return this.each(function(){if(!this.grid||!this.p.treeGrid){return}var e,b,f,g=c(this).getNodeChildren(k);g.sort(function(a,d){if(a.sortKey<d.sortKey){return-l}if(a.sortKey>d.sortKey){return l}return 0});for(e=0,b=g.length;e<b;e++){f=g[e];i.push(f);c(this).collectChildrenSortTree(i,f,l)}})},setTreeRow:function(d,e){var b,f=false;this.each(function(){var a=this;if(!a.grid||!a.p.treeGrid){return}f=c(a).setRowData(d,e)});return f},delTreeNode:function(f){return this.each(function(){var a=this;if(!a.grid||!a.p.treeGrid){return}var d=c(a).getInd(a.rows,f,true);if(d){var e=c(a).getNodeChildren(d);if(e.length>0){for(var b=0;b<e.length;b++){c(a).delRowData(e[b].id)}}c(a).delRowData(d.id)}})}})})(jQuery);