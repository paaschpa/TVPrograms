using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TVPrograms.UI;
using System.Collections.Generic;
using System.Globalization;
using TVPrograms.Core.Domain.Model;

namespace TVPrograms.UI.Helpers
{
    public class ProgramScheduleExtension
    {
        private static readonly DateTime startdate = Convert.ToDateTime("1/1/2007");
        private static readonly DateTime enddate = Convert.ToDateTime("12/31/2009");

        public static string BuildHeaderRow()
        {
            List<WeeklyData> AllWeeks = getAllWeeksInRange(startdate, enddate);
            int prevQuarter = 0;
            String ret = "<table cellpadding=0 and cellspacing=0><tr>";
            foreach (WeeklyData week in AllWeeks)
            {
                if (week.Quarter != prevQuarter)
                {
                    ret = ret + "<td>" + week.Year + "-" + week.Quarter + " </td>";
                }
                prevQuarter = week.Quarter;
            }

            ret = ret + "</tr></table>";
            return ret;
        }

        public static string BuildAirDateCalendar(IList<Season> seasons)
        {
            String ret = "";
            int prevMonth = 0;
            int prevQuarter = 0;
            List<WeeklyData> AllWeeks = getAllWeeksInRange(startdate, enddate);
            
            AllWeeks = PopulateWithProgramming(AllWeeks, seasons);
            prevMonth = AllWeeks[0].StartDate.Month;
            prevQuarter = AllWeeks[0].Quarter;
            ret = "<table cellpadding=0 and cellspacing=0><tr><td class='blueBorder'>" + YearQuarterText(AllWeeks[0]) + "<table cellpadding=0 and cellspacing=0><tr><td> <table cellpadding=0 and cellspacing=0 class='blueBorder'><tr>";

            foreach (WeeklyData week in AllWeeks)
            {
                ret = ret + BuildWeekCellWrap(week, prevQuarter, prevMonth);

                prevQuarter = week.Quarter;
                prevMonth = week.StartDate.Month;
            }

            ret = ret + "</tr></table> </td></tr></table>  </td></tr></table>";
            return ret;
        }

        public static List<WeeklyData> getAllWeeksInRange(DateTime startdate, DateTime enddate)
        {
            List<WeeklyData> ret = new List<WeeklyData>();
            GregorianCalendar cal = new GregorianCalendar();
            for (DateTime datecounter = startdate; datecounter <= enddate; datecounter = datecounter.AddDays(7))
            {
                WeeklyData programweek = new WeeklyData();
                programweek.StartDate = datecounter;
                programweek.EndDate = datecounter.AddDays(7);
                programweek.Year = datecounter.Year;
                programweek.WeekNumber = cal.GetWeekOfYear(datecounter, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                programweek.Quarter = getQuarter(datecounter.Month);
                ret.Add(programweek);
            }

            return ret;
        }

        public static String BuildWeekCellWrap(WeeklyData week, int prevQuarter, int prevMonth)
        {
            String ret = "";
            if (week.Quarter != prevQuarter && week.StartDate.Month != prevMonth)
            {
                ret = ret + "</tr></table> </tr></td></table>  </td><td class='blueBorder'>" + YearQuarterText(week) + "<table cellpadding=0 and cellspacing=0><tr><td> <table cellpadding=0 and cellspacing=0 class='blueBorder'><tr>" + BuildWeekCell(week.hasProgramming);
            }
            else if (week.StartDate.Month != prevMonth)
            {
                ret = ret + "</tr></table> </td><td>  <table cellpadding=0 and cellspacing=0 class='blueBorder'><tr>" + BuildWeekCell(week.hasProgramming);
            }
            else
            {
                ret = ret + BuildWeekCell(week.hasProgramming);
            }

            return ret;
        }

        public static String BuildWeekCell(bool hasProgamming)
        {
            if (hasProgamming == true)
            {
                return "<td class='yellowFill'><span class='yellowFill'></span></td>";
            }

            return "<td class='whiteFill'><span class='whiteFill'></span></td>";
        }

        public static List<WeeklyData> PopulateWithProgramming(List<WeeklyData> AllWeeks, IList<Season> seasons)
        {
             
            foreach(Season season in seasons)
             {
                 CompareEpisodesWithDates(AllWeeks, season.Episodes);
             }

            return AllWeeks;
        }

        public static void CompareEpisodesWithDates(List<WeeklyData> AllWeeks, IList<Episode> episodes)
        {
            GregorianCalendar cal = new GregorianCalendar();

            foreach(WeeklyData week in AllWeeks)
            {
                foreach(Episode episode in episodes)
                {
                    int episodeWeekNumber = cal.GetWeekOfYear(episode.AirDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    if (week.Year == episode.AirDate.Year && week.WeekNumber == episodeWeekNumber)
                    {
                        week.hasProgramming = true;
                    }
                }
            }
        }

        public static int getQuarter(int month)
        {
            int ret = 0;
            switch (month)
            {
                case 1: case 2: case 3:  
                    ret = 1;
                    break;
                case 4: case 5: case 6:
                    ret = 2;
                    break;
                case 7: case 8: case 9:
                    ret = 3;
                    break;
                case 10: case 11: case 12:
                    ret = 4;
                    break;
                default:
                    break;
            }
            return ret;
        }

        public static string YearQuarterText(WeeklyData week)
        { 
            return "<div style='font-size:7pt; width:50px;'>" + week.Year + " - " + week.Quarter + "</div>";
        }

    }

    public class WeeklyData
    {
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int WeekNumber { get; set; }
        public virtual int Year { get; set; }
        public virtual int Quarter {get; set;}
        public virtual bool hasProgramming { get; set; }
    }
}