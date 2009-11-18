<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<Network[]>" %>
<%@ Import Namespace="TVPrograms.Core.Domain.Model"%>
<%@ Import Namespace="TVPrograms.UI.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.yellowFill { background-color:yellow;border: solid 1px yellow}
.whiteFill { background-color:white;border: solid 1px white}
.blueBorder { border-right: solid 1px blue; border-top: solid 1px blue; border-bottom: solid 1px blue;}
.blueBorderFirstCol  { border: solid 1px blue; width:150px; padding-left:5px; }
table td {padding:0px; border-spacing:0px; border-collapse:collapse; height:25px; width:25px;}
</style>

<script language="javascript">

    $(document).ready(function() {
        $("#ddlNetworks").change(function() {
            var NetworkID = $('#ddlNetworks').val();
            if (NetworkID != 0) {
                $.getJSON('ListJsonData/' + NetworkID, function(data) {
                    //Set and Apply template
                    $('#dvPrograms').setTemplateElement('jtemplate');
                    $('#dvPrograms').processTemplate(data);
                });
            }
        });
    });

</script>


<%using (Html.BeginForm()) {%>
<%=Html.DropDownList("ddlNetworks")%>
<%} %>

<!-- Template content -->
<textarea id="jtemplate" style="display:none">
<table cellpadding="0" cellspacing="0">
    <tr>
        <th>Program Name</th>
        <th>Air Dates By Quarter</th>
    </tr>
      {#foreach $T.Programs as program}
    <tr>
        <td class="blueBorderFirstCol">
            {$T.program.ProgramName}
        </td>
        <td>
            <table>
                <tr>
                    {#foreach $T.program.Seasons as season}
                        {#foreach $T.season.Episodes as episode}
                        <td>{$T.episode.AirDate}</td>
                        {#/for}
                    {#/for}
                </tr>
            </table>
            
        </td>
    </tr>
	{#/for}
</table>
</textarea>

<!-- Output elements -->
<div id="dvPrograms" class="jTemplatesTest"></div>

</asp:Content>