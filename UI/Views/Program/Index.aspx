<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<ProgramForm>" %>
<%@ Import Namespace="TVPrograms.UI.Models.Forms"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <strong>Series Review for <%=Model.ProgramName %></strong>
    <table width="500">
        <tr>
            <th class="tableHeader">Season</th>
            <th class="tableHeader">Start Date</th>
            <th class="tableHeader">End Date</th>
            <th class="tableHeader">Episode Count</th>
            <th class="tableHeader">Weighted Rating</th>
        </tr>
        <% foreach (object[] obj in (List<object[]>)ViewData["SeasonReport"])
           { %>
            <tr>
                <td><%= obj[0].ToString() %></td>
                <td><%= Convert.ToDateTime(obj[1]).ToString("d") %></td>
                <td><%= Convert.ToDateTime(obj[2]).ToString("d") %></td>
                <td><%= obj[3].ToString() %></td>
                <td><%= obj[4].ToString() %></td>
            </tr>
        <% } %>
        
    </table>
    <p></p>    
    <% foreach (SeasonForm season in Model.Seasons.OrderBy(season => season.SeasonNumber).Reverse())
                { %>
        <strong>Season <%= season.SeasonNumber %> Episode Review</strong>
        <table width="500">
            <tr>
                <th class="tableHeader">Air Date</th>
                <th class="tableHeader">Day</th>
                <th class="tableHeader">Time</th>
                <th class="tableHeader">Duration</th>
                <th class="tableHeader">Rating</th>
            </tr>
            <% foreach (EpisodeForm episode in season.Episodes.OrderBy(episode => episode.AirDate).Reverse()){ %>
            <tr>
                <td><%= episode.AirDate %></td>
                <td><%= episode.AirDateDay %></td>
                <td><%= episode.StartTime %></td>
                <td><%= episode.Duration %></td>
                <td><%= episode.HHLD_Proj %></td>
            </tr>
            <% } %>
          </table>
          <p></p>  
        <% } %>
        
<p></p>
Add 'Json' to url (/Program/IndexJson/{id}) to see same page using jquery and json. 
<p></p>
<b>What's going on?</b>
<ul>
    <li>This page uses the ProgramRepository to get our data. AutoMapper maps the data to 'View Model' (/Models/Forms/ProgramForm) </li>
    <li>The 'View Model' puts a little make up on data and adds +5 to the data's handsomenes (I doubt the code I wrote is the proper way to handle converting the data, but it works)</li>
    <li>Some loop nesting is going on <i>(I hope no one's pregnant - google 'nesting instinct' if you don't get the joke...still not funny? Well, maybe you just don't know funny)</i></li>
    <li>I used Nhibernate's CreateSQLQuery to write a custom SQL statment that does math to determine the weighted average<i>(I'll never forgive you Nhibernate for making me do SQL work...yes, of course cuddling will help the healing process.)</i></li>
</ul>
</asp:Content>
