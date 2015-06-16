using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TeamworkReporter.Models.Timelogs;

namespace TeamworkReporter.Types
{
    public static class PeriodsHelper
    {
        private static CultureInfo enUsCulture = new CultureInfo("en-US");

        public static DateTime[] GetPeriods(DateTime current, TimelogsPeriod period, int numberOfPeriods = 9)
        {
            if (numberOfPeriods == 0)
                return new DateTime[] { };

            if (period == TimelogsPeriod.Daily)
            {
                var datePoints = new List<DateTime>();
                for (var i = numberOfPeriods-1; i >= 1; i--)
                    datePoints.Add(current.AddDays(-i).Date);
                datePoints.Add(current);
                return datePoints.ToArray();
            }

            if (period == TimelogsPeriod.Weekly)
            {
                var datePoints = new List<DateTime>();
                var weekStartingDate = GetWeekStart(current);
                for (var i = numberOfPeriods - 1; i >= 1; i--)
                    datePoints.Add(weekStartingDate.AddDays(-7*i));
                datePoints.Add(weekStartingDate);
                return datePoints.ToArray();

            }
            if (period == TimelogsPeriod.Monthly)
            {
                var datePoints = new List<DateTime>();
                var monthStartingDate = new DateTime(current.Year, current.Month, 1);
                for (var i = numberOfPeriods - 1; i >= 0; i--)
                    datePoints.Add(monthStartingDate.AddMonths(-i));
                return datePoints.ToArray();
            }
            return new DateTime[] { };
        }

        public static DateTime GetWeekStart(DateTime current)
        {
            // Enum DayOfWeek is starting from Sun. That means if current day is Monday, then nothing should be ksubtracted since our week starts on Monday.
            // For Saturday 5 days should be subtracted to get Monday. The formula below descibe this.
            var subtraction = current.DayOfWeek == DayOfWeek.Sunday ? 6 : ((int) current.DayOfWeek - 1);
            return current.AddDays(-subtraction).Date;
        }

        private static void AddWeekName(List<string> weeks, DateTime weekStart, DateTime weekEnd)
        {
            var monthNames = enUsCulture.DateTimeFormat.AbbreviatedMonthNames;
            weeks.Add(weekStart.Month != weekEnd.Month
                ? string.Format("{0:00},{1}-{2:00},{3}", weekStart.Day, monthNames[weekStart.Month - 1], weekEnd.Day, monthNames[weekEnd.Month - 1])
                : weekStart.Day != weekEnd.Day
                    ? string.Format("{0:00}-{1:00},{2}", weekStart.Day, weekEnd.Day, monthNames[weekStart.Month - 1])
                    : string.Format("{0:00},{1}", weekStart.Day, monthNames[weekStart.Month - 1]));
        }

        public static IEnumerable<string> ConvertToNames(this DateTime[] periods, TimelogsPeriod period, DateTime current)
        {
            if (period == TimelogsPeriod.Daily)
            {
                return periods.Select(p => p.ToString("dd/MM/yy"));
            }

            if (period == TimelogsPeriod.Weekly)
            {
                if (periods.Last() > current.Date)
                    throw new ArgumentException("Current date should be greate or equal to the ending period.", "current");
                var weeks = new List<string>();
                for (var i = 0; i <= periods.Length - 2; i++)
                {
                    var w1 = periods[i];
                    var w2 = periods[i + 1].AddSeconds(-1);
                    AddWeekName(weeks, w1, w2);
                }
                AddWeekName(weeks, periods.Last(), current.Date);
                return weeks;
            }

            if (period == TimelogsPeriod.Monthly)
            {
                return periods.Select(GetMonthName);
            }
            throw new NotSupportedException();
        }

        public static string GetMonthName(DateTime date)
        {
            var monthNames = enUsCulture.DateTimeFormat.AbbreviatedMonthNames;
            return string.Format("{0},{1}", monthNames[date.Month-1], date.Year.ToString().Substring(2,2));
        }
    }
}