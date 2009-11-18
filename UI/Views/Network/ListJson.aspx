<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<Network>" %>
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

<script language="JavaScript" type="text/javascript">

    $(document).ready(function() {

        ajaxDataCall($('#ddlNetworks').val());

        $("#ddlNetworks").change(function() {
            var NetworkID = $('#ddlNetworks').val();
            if (NetworkID != 0) {
                ajaxDataCall(NetworkID);
            }
        });
    });

    function ajaxDataCall(id) {
        //alert('Im being called ' + id );
        $.ajax({
            url: '/Network/ListData/' + id,
            dataType: 'html',
            success: function(data) {
                $('#dvPrograms').html(data);
            }
        });
    }
    
</script>  


<%using (Html.BeginForm()) {%>
<%=Html.DropDownList("ddlNetworks")%>
<%} %>


<!-- Output elements -->
<div id="dvPrograms">Nothing</div>

</asp:Content>