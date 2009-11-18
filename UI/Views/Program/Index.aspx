<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
Inherits="System.Web.Mvc.ViewPage<Program>" %>
<%@ Import Namespace="TVPrograms.Core.Domain.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    Series Review
    <table>
        <th>Season</th>
        <th>Start Date</th>
        <th>End Date</th>
        <th>Episode Count</th>
        <th>Average Rating</th>
        <% foreach (Season season in Model.Seasons.OrderBy(season => season.SeasonNumber).Reverse())
           { %>
            <tr>
                <td><%= season.SeasonNumber %></td>
                <td><%= season.StartDate.ToString("d") %></td>
                <td><%= season.EndDate.ToString("d") %></td>
                <td><%= season.Episodes.Count %></td>
            </tr>
        <% } %>
        
        <% foreach (object[] obj in (List<object[]>)ViewData["SeasonReport"])
           { %>
            <tr>
                <td><%= obj[0].ToString() %></td>
                <td><%= obj[1].ToString() %></td>
                <td><%= obj[2].ToString() %></td>
                <td>xx</td>
            </tr>
        <% } %>
        
    </table>


    Season Review
    <% foreach (Season season in Model.Seasons.OrderBy(season => season.SeasonNumber).Reverse())
                { %>
        <%= season.SeasonNumber %>
        <table>
            <th>Date</th>
            <th>Day</th>
            <th>Time</th>
            <th>Duration</th>
            <th>Rating</th>
            <% foreach (Episode episode in season.Episodes.OrderBy(episode => episode.AirDate).Reverse()){ %>
            <tr>
                <td><%= episode.AirDate.ToString("d")%></td>
                <td><%= episode.AirDate.ToString("ddd") %></td>
                <td><%= episode.StartTime.ToString("t") %></td>
                <td><%= episode.Duration %></td>
                <td><%= episode.HHLD_Proj %></td>
            </tr>
            <% } %>
          </table>    
        <% } %>
        
<p></p>
Add 'Json' to url (/Program/IndexJson/{id}) to see same page using jquery and json. 
<p></p>
<b>What's going on?</b>
<ul>
    <li>This page uses the ProgramRepository and cycles the List of Seasons and List of Episodes (within the Season). </li>
    <li>Some loop nesting is going on <i>(I hope no ones pregnant)</i></li>
    <li>I used Nhibernate's CreateSQLQuery to write a custom SQL statment that does math <i>(I'll never forgive you Nhibernate for making me do work...yes, of course cuddling will help.)</i></li>
</ul>
</asp:Content>
