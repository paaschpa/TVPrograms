<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<Network[]>" %>
<%@ Import Namespace="TVPrograms.Core.Domain.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%using (Html.BeginForm()) {%>
<%=Html.DropDownList("ddlNetworks", null, new { onChange = "this.form.submit()" })%>
<%} %>

<% if(Model.Length>0){ %>

    <%Html.RenderPartial("ProgramList",Model[0].Programs); %>
    
<%} %>

</asp:Content>
