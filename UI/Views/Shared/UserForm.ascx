<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserForm>" %>
<%@ Import Namespace="TVPrograms.UI.Models.Forms"%>

<% using(Html.BeginForm("Save")) { %>

        <fieldset>
            <legend>User Profile</legend>
            <table>
            <tr>
                <td></td>
                <td><%=Html.Hidden("id", Model.id)%></td>
            </tr>
            <tr>
                <td>Username:</td>
                <td><%=Html.TextBox("username", Model.Username)%></td>
            </tr>
            <tr>
                <td>Full Name:</td>
                <td><%=Html.TextBox("fullname", Model.FullName)%> </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><%=Html.TextBox("emailaddress", Model.EmailAddress)%> </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><%=Html.TextBox("password", Model.Password)%> </td>
            </tr>
            <tr>
                <td>Confirm Password: </td>
                <td><%=Html.TextBox("confirmpassword", Model.ConfirmPassword)%></td>
            </tr>
            </table>
			<p class="buttons">
			    <input type="submit" value="Save" />
			    <%= Html.ActionLink("Cancel", "Index") %>				
			</p>
		</fieldset>			

<% } %>