<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	IndexJson
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
    //this part will only work in the current set up since the string has the
    //ID parameter in it.  If the route naming changes (say has slug) this will
    //blow up...BOOM
        var pathname = window.location.pathname;
        var ID = pathname.substring(pathname.lastIndexOf("/") + 1) 
    //************************************************************************  
    jQuery("#list").jqGrid({
        url: '../IndexJsonData/' + ID,
        datatype: 'json',
        mtype: 'GET',
        colNames: ['ProgramName', 'SeasonNumber', 'Rating'],
        colModel: [
            { name: 'ProgramName', index: 'ProgramName', width: 200, align: 'left' },
            { name: 'SeasonNumber', index: 'SeasonNumber', width: 200, align: 'left' },
            { name: 'Rating', index: 'Rating', width: 200, align: 'left'}],

        pager: jQuery('#pager'),
        rowNum: 10,
        rowList: [5, 10, 20, 50],
        //sortname: 'Id',
        //sortorder: "desc",
        viewrecords: true,
        imgpath: '/scripts/themes/basic/images',
        caption: 'My first grid'
    });
});

</script>


<h2>My Grid Data</h2>
<table id="list" class="scroll" cellpadding="0" cellspacing="0"></table>
<div id="pager" class="scroll" style="text-align:center;"></div>


</asp:Content>
