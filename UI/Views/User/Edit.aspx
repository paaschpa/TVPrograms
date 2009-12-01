<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<UserForm>" %>
<%@ Import Namespace="TVPrograms.UI.Models.Forms"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% if (ViewData.ModelState.Count > 0)
   {
       Response.Write(Html.ValidationSummary());
   }       
%>

<%Html.RenderPartial("UserForm",Model); %>

</asp:Content>
