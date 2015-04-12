using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.Models.Timelogs;

namespace TeamworkReporter.Types.Tests
{
    [TestClass]
    public class PeriodsHelperTests
    {
        [TestMethod]
        public void GetPeriods_should_return_9_default_periods()
        {
            const int expected = 9;
            var actual = PeriodsHelper.GetPeriods(DateTime.Now, TimelogsPeriod.Daily).Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPeriods_should_return_requested_number_of_periods()
        {
            const int expected = 18;
            var actual = PeriodsHelper.GetPeriods(DateTime.Now, TimelogsPeriod.Daily, expected).Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPeriods_should_return_zero_periods()
        {
            const int expected = 0;
            var actual = PeriodsHelper.GetPeriods(DateTime.Now, TimelogsPeriod.Daily, expected).Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPeriods_should_return_date_for_Daily()
        {
            var currentDate = DateTime.Now;
            var expected = new[]
            {
                currentDate.AddDays(-8).Date,
                currentDate.AddDays(-7).Date,
                currentDate.AddDays(-6).Date,
                currentDate.AddDays(-5).Date,
                currentDate.AddDays(-4).Date,
                currentDate.AddDays(-3).Date,
                currentDate.AddDays(-2).Date,
                currentDate.AddDays(-1).Date,
                currentDate
            };
            var actual = PeriodsHelper.GetPeriods(currentDate, TimelogsPeriod.Daily, 9);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void GetPeriods_should_return_date_for_Weekly()
        {
            var currentDate = DateTime.Now;
            var weekStartDate = PeriodsHelper.GetWeekStart(currentDate);

            // expected periods should include the current one even if it is not finished yet
            var expected = new[]
            {
                weekStartDate.AddDays(-7*8),
                weekStartDate.AddDays(-7*7),
                weekStartDate.AddDays(-7*6),
                weekStartDate.AddDays(-7*5),
                weekStartDate.AddDays(-7*4),
                weekStartDate.AddDays(-7*3),
                weekStartDate.AddDays(-7*2),
                weekStartDate.AddDays(-7*1),
                weekStartDate
            };
            var actual = PeriodsHelper.GetPeriods(DateTime.Now, TimelogsPeriod.Weekly, 9);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void GetPeriods_should_return_date_for_Monthly()
        {
            var currentDate = DateTime.Now;
            var monthStartDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // expected periods should include the current one even if it is not finished yet
            var expected = new[]
            {
                monthStartDate.AddMonths(-8),
                monthStartDate.AddMonths(-7),
                monthStartDate.AddMonths(-6),
                monthStartDate.AddMonths(-5),
                monthStartDate.AddMonths(-4),
                monthStartDate.AddMonths(-3),
                monthStartDate.AddMonths(-2),
                monthStartDate.AddMonths(-1),
                monthStartDate
            };
            var actual = PeriodsHelper.GetPeriods(DateTime.Now, TimelogsPeriod.Monthly, 9);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void ConvertToNames_for_Daily_periods()
        {
            var currentDate = DateTime.Now;
            var expected = new[]
            {
                currentDate.AddDays(-8).ToString("dd/MM/yy"),
                currentDate.AddDays(-7).ToString("dd/MM/yy"),
                currentDate.AddDays(-6).ToString("dd/MM/yy"),
                currentDate.AddDays(-5).ToString("dd/MM/yy"),
                currentDate.AddDays(-4).ToString("dd/MM/yy"),
                currentDate.AddDays(-3).ToString("dd/MM/yy"),
                currentDate.AddDays(-2).ToString("dd/MM/yy"),
                currentDate.AddDays(-1).ToString("dd/MM/yy"),
                currentDate.ToString("dd/MM/yy")
            };
            var periods = PeriodsHelper.GetPeriods(currentDate, TimelogsPeriod.Daily, 9);
            var actual = periods.ConvertToNames(TimelogsPeriod.Daily, DateTime.Now);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void ConvertToNames_for_Weekly_periods()
        {
            // chose the current date so that
            // #1 the current week is not finished yet
            // #2 some of the previous weeks is starting and ending in different monthes

            var currentDate = new DateTime(2015, 4, 9); // thu
            var expected = new[]
            {
                "09-15,Feb",
                "16-22,Feb",
                "23,Feb-01,Mar",
                "02-08,Mar",
                "09-15,Mar",
                "16-22,Mar",
                "23-29,Mar",
                "30,Mar-05,Apr",
                "06-09,Apr"
            };
            var periods = PeriodsHelper.GetPeriods(currentDate, TimelogsPeriod.Weekly, 9);
            var actual = periods.ConvertToNames(TimelogsPeriod.Weekly, currentDate);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void ConvertToNames_for_Monthly_periods()
        {
            var monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
            var currentDate = new DateTime(2015, 4, 9);
            var expected = new[]
            {
                monthNames[currentDate.AddMonths(-8).Month-1],
                monthNames[currentDate.AddMonths(-7).Month-1],
                monthNames[currentDate.AddMonths(-6).Month-1],
                monthNames[currentDate.AddMonths(-5).Month-1],
                monthNames[currentDate.AddMonths(-4).Month-1],
                monthNames[currentDate.AddMonths(-3).Month-1],
                monthNames[currentDate.AddMonths(-2).Month-1],
                monthNames[currentDate.AddMonths(-1).Month-1],
                monthNames[currentDate.Month-1]
            };
            var periods = PeriodsHelper.GetPeriods(currentDate, TimelogsPeriod.Monthly, 9);
            var actual = periods.ConvertToNames(TimelogsPeriod.Monthly, DateTime.Now);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod]
        public void GetWeekStart_calculate_for_Monday()
        {
            var expected = new DateTime(2015, 4, 6);
            var current = new DateTime(2015, 4, 6);
            var actual = PeriodsHelper.GetWeekStart(current);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeekStart_calculate_for_Saturday()
        {
            var expected = new DateTime(2015, 4, 6);
            var current = new DateTime(2015, 4, 11);
            var actual = PeriodsHelper.GetWeekStart(current);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeekStart_calculate_for_Sunday()
        {
            var expected = new DateTime(2015, 4, 6);
            var current = new DateTime(2015, 4, 12);
            var actual = PeriodsHelper.GetWeekStart(current);
            Assert.AreEqual(expected, actual);
        }
    }
}