using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamworkReporter.Models.Timelogs;

namespace TeamworkReporter.Types
{
    public static class PeriodsHelper
    {
        public static DateTime[] GetPeriods(DateTime current, TimelogsPeriod period, int numberOfPeriods = 9)
        {
            if (period == TimelogsPeriod.Daily)
            {
                var datePoints = new List<DateTime>();
                for (var i = numberOfPeriods-1; i >= 0; i--)
                    datePoints.Add(current.AddDays(-i));
                return datePoints.ToArray();
            }

            if (period == TimelogsPeriod.Weekly)
            {
                var datePoints = new List<DateTime>();

            }
            if (period == TimelogsPeriod.Monthly)
            {
                var datePoints = new List<DateTime>();

            }
            return new DateTime[] { };
        }

        public static IEnumerable<string> ConvertToNames(this DateTime[] periods, TimelogsPeriod timelogsPeriod)
        {
            return periods.Select(p => p.ToString("dd/MM/yy"));
        }
    }
}