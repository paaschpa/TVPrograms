<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<UserForm>" %>
<%@ Import Namespace="TVPrograms.UI.Models.Forms"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% using(Html.BeginForm("Save")) { %>

        <fieldset>
            <legend>User Profile</legend>
        
            <%=Html.Hidden("id", Model.id)%>            	
			<%=Html.TextBox("username", Model.Username)%>
			<%=Html.TextBox("fullname", Model.FullName)%>
			<%=Html.TextBox("emailaddress", Model.EmailAddress)%>
			<%=Html.TextBox("password", Model.Password)%>
			<%=Html.TextBox("confirmpassword", Model.ConfirmPassword)%>
			
			<p class="buttons">
			    <input type="submit" value="Save" />
			    <%= Html.ActionLink("Cancel", "Index") %>				
			</p>
		</fieldset>			

<% } %>

</asp:Content>
