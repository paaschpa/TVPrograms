<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Program>>" AutoEventWireup="true" %>
<%@ Import Namespace="TVPrograms.Core.Domain.Model"%>
<%@ Import Namespace="TVPrograms.UI.Helpers" %>
<style type="text/css">
.yellowFill { background-color:yellow;border: solid 1px yellow}
.whiteFill { background-color:white;border: solid 1px white}
.blueBorder { border-right: solid 1px blue; border-top: solid 1px blue; border-bottom: solid 1px blue;}
.blueBorderFirstCol  { border: solid 1px blue; width:150px; padding-left:5px; }
table td {padding:0px; border-spacing:0px; border-collapse:collapse; height:25px; width:25px;}
</style>

<div style="text-align:right; font-weight:bold"></strong>Key:<span class="yellowFill">New Episode Air Date(s)</span></div>
 <table cellpadding="0" cellspacing="0">
		  <tr>
				<th>Program Name</th>
		        <th>New Episode Air Dates By Quarter <i>(good-looking people don't watch reruns)</i></th>
		  </tr>
	      <% foreach (var program in Model) 
                { 
          %>
		  <tr>
				<td class="blueBorderFirstCol">
				    <%= Html.RouteLink(program.ProgramName, new { controller = "Program", action = "Index", id = program.id }) %>
				</td>
				<td><%= ProgramScheduleExtension.BuildAirDateCalendar(program.Seasons) %></td>
		  </tr>
		  <% 
                }
		  %>
		  </table>

