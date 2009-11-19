<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<Network>" %>
<%@ Import Namespace="TVPrograms.Core.Domain.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%using (Html.BeginForm()) {%>
<%=Html.DropDownList("ddlNetworks", null, new { onChange = "this.form.submit()" })%>
<%} %>

<% if(Model != null){ %>

    <%Html.RenderPartial("ProgramList",Model.Programs); %>
    
<%} %>
<p></p>
Add 'Json' to url (/Network/ListJson) to see same page using jquery and json. It's no different, I just employed
a technique know as Jsonificationerizing. 
<p></p>
<b>What's going on?</b>
<ul>
<li>This page uses the NetworkRepository to populate the dropdown list. <i>(thanks for the data Nhibernate)</i></li>
<li>Next, it gets the first Network model <i>(of the non-good-looking variety)</i> and passes it on to the view (this page) </li>
<li>If you don't believe me go look at the code in NetworkController.</li>  
<li>The view gets the List of Programs from the ugly model and passes it to a ProgramList partial. (all the data relations are done by the Fluent Nhibernate mapping.  <i>All sexy relations are done by me...this joke needs some reworking</i>)</li>
<li>The ProgramList partial returns the Air Date grid using an ugly extension I cooked up.  My normal extension is much more pleasant <i>(or so the ladies tell me, zing)</i></li>
</ul>
</asp:Content>
