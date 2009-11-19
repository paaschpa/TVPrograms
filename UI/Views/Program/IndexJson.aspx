<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	IndexJson
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function() {
    //this part will only work in the current set up since the string has the
    //ID parameter in it.  If the route naming changes (say has a slug) this will
    //blow up...BOOM...that was just a warning
        var pathname = window.location.pathname;
        var ID = pathname.substring(pathname.lastIndexOf("/") + 1)
    //************************************************************************

    jQuery("#list").jqGrid({
        url: '../IndexJsonSeasonData/' + ID,
        datatype: 'json',
        mtype: 'GET',
        colNames: ['SeasonNumber', 'Start Date', 'End Date', 'Episode Count', 'Weigthed Rating'],
        colModel: [
            { name: 'SeasonNumber', index: 'SeasonNumber', width: 200, align: 'left', sortable: 'true', sorttype: 'int' },
            { name: 'StartDate', index: 'StartDate', width: 200, align: 'left' },
            { name: 'EndDate', index: 'EndDate', width: 200, align: 'left' },
            //I left name: blank in the items below to show that I don't know what it does. The name:
            //property is required but I'm sooo good-looking I don't need to populate it (I'm sure there 
            //is an actual reason, but I don't know it).  
            { name: '', index: '', width: 200, align: 'left' },
            { name: '', index: '', width: 200, align: 'left' }
            ],
        pager: jQuery('#pager'),
        rowNum: 10,
        sortname: 'SeasonNumber',
        sortorder: "asc",
        rowList: [5, 10, 20, 50],
        viewrecords: true,
        imgpath: '/scripts/themes/basic/images',
        caption: 'Series Review',
        height: 75,
        width: 600
    });

    if (ID != 0) {
        $.getJSON('../IndexJsonEpisodes/' + ID, function(data) {
            //Set and Apply template
            $('#dvSeasonDetail').setTemplateElement('jtemplate');
            $('#dvSeasonDetail').processTemplate(data);
        });
    }
});


</script>

<h2>My Grid Data</h2>
<table id="list" class="scroll" cellpadding="0" cellspacing="0"></table>
<div id="pager" class="scroll" style="text-align:center;"></div>

<!-- Template content -->
<textarea id="jtemplate" style="display:none">

{#foreach $T.Seasons as season}
<p></p>
Season {$T.season.SeasonNumber} Episode Review
<table cellpadding="0" cellspacing="0" width="500">
    <tr>
        <th class="tableHeader">Air Date</th>
        <th class="tableHeader">Day</th>
        <th class="tableHeader">Time</th>
        <th class="tableHeader">Duration</th>
        <th class="tableHeader">Rating</th>
    </tr>
        {#foreach $T.season.Episodes as episode}
          <tr>
            <td>{$T.episode.AirDate}</td>
            <td>{$T.episode.AirDateDay}</td>
            <td>{$T.episode.StartTime}</td>
            <td>{$T.episode.Duration}</td>
            <td>{$T.episode.HHLD_Proj}</td>
          </tr>
        {#/for}
</table>
{#/for}
</textarea>

<!-- Output Template elements -->
<div id="dvSeasonDetail"></div>

</asp:Content>
