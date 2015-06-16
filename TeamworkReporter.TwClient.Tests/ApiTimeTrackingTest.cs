using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiTimeTrackingTest : ApiTestSetup
    {
        private readonly IProxyTimeTracking _apiTimeTracking;

        public ApiTimeTrackingTest()
        {
            _apiTimeTracking = Api;
        }

        [TestCategory("Time Tracking API Calls")]
        [TestMethod]
        public void Should_return_all_time_entries_for_all_projects()
        {
            var timeEntries = _apiTimeTracking.Get();

            Assert.IsNotNull(timeEntries);
            var twTimeEntries = timeEntries as TwTimeEntry[] ?? timeEntries.ToArray();
            Assert.AreEqual(4, twTimeEntries.Length);

            Assert.AreEqual("Task 1 in the list 2 of the project 1", twTimeEntries[0].TaskName);
            Assert.AreEqual(1, twTimeEntries[0].Hours);
            Assert.AreEqual(30, twTimeEntries[0].Minutes);

            Assert.AreEqual("Task 1 in the list 1 of the project 1", twTimeEntries[1].TaskName);
            Assert.AreEqual(2, twTimeEntries[1].Hours);
            Assert.AreEqual(45, twTimeEntries[1].Minutes);

            Assert.AreEqual("Task 1 in the list 1 of the project 2", twTimeEntries[2].TaskName);
            Assert.AreEqual(3, twTimeEntries[2].Hours);
            Assert.AreEqual(0, twTimeEntries[2].Minutes);

            Assert.AreEqual(string.Empty, twTimeEntries[3].TaskName);
            Assert.IsNull(twTimeEntries[3].TaskId);
            Assert.AreEqual(4, twTimeEntries[3].Hours);
            Assert.AreEqual(0, twTimeEntries[3].Minutes);
        }

        [TestCategory("Time Tracking API Calls")]
        [TestMethod]
        public void Should_return_time_trackings_for_single_project()
        {
            var timeEntries = _apiTimeTracking.GetByProject(67094);
            Assert.IsNotNull(timeEntries);
            var twTimeEntries = timeEntries as TwTimeEntry[] ?? timeEntries.ToArray();
            Assert.AreEqual(2, twTimeEntries.Count());

            Assert.AreEqual("Task 1 in the list 2 of the project 1", twTimeEntries[0].TaskName);
            Assert.AreEqual(1, twTimeEntries[0].Hours);
            Assert.AreEqual(30, twTimeEntries[0].Minutes);

            Assert.AreEqual("Task 1 in the list 1 of the project 1", twTimeEntries[1].TaskName);
            Assert.AreEqual(2, twTimeEntries[1].Hours);
            Assert.AreEqual(45, twTimeEntries[1].Minutes);
        }

        [TestCategory("Time Tracking API Calls")]
        [TestMethod]
        public void Should_return_time_trackings_for_task()
        {
            var timeEntries = _apiTimeTracking.GetByTask(1255801);
            Assert.IsNotNull(timeEntries);
            var twTimeEntries = timeEntries as TwTimeEntry[] ?? timeEntries.ToArray();
            Assert.AreEqual(1, twTimeEntries.Count());

            Assert.AreEqual("Task 1 in the list 2 of the project 1", twTimeEntries[0].TaskName);
            Assert.AreEqual(1, twTimeEntries[0].Hours);
            Assert.AreEqual(30, twTimeEntries[0].Minutes);
        }

        [TestCategory("Time Tracking API Calls")]
        [TestMethod]
        public void Should_return_time_trackings_withing_date_range()
        {
            var timeEntries = _apiTimeTracking.Get(new DateTime(2014, 5, 2), new DateTime(2014, 5, 3)); // from 2 to 3 of May => 2 entries
            Assert.IsNotNull(timeEntries);
            var twTimeEntries = timeEntries as TwTimeEntry[] ?? timeEntries.ToArray();
            Assert.AreEqual(2, twTimeEntries.Count());

            Assert.AreEqual("Task 1 in the list 1 of the project 1", twTimeEntries[0].TaskName);
            Assert.AreEqual(2, twTimeEntries[0].Hours);
            Assert.AreEqual(45, twTimeEntries[0].Minutes);

            Assert.AreEqual("Task 1 in the list 1 of the project 2", twTimeEntries[1].TaskName);
            Assert.AreEqual(3, twTimeEntries[1].Hours);
            Assert.AreEqual(0, twTimeEntries[1].Minutes);
        }

        [TestCategory("Time Tracking API Calls")]
        [TestMethod]
        public void Should_return_time_trackings_withing_date_range_for_single_project()
        {
            var timeEntries = _apiTimeTracking.GetByProject(67099, new DateTime(2014, 5, 2), new DateTime(2014, 5, 3)); // from 2 to 3 of May => 1 entry for this project 'Test project 2 - xtrmtest2'
            Assert.IsNotNull(timeEntries);
            var twTimeEntries = timeEntries as TwTimeEntry[] ?? timeEntries.ToArray();
            Assert.AreEqual(1, twTimeEntries.Count());

            Assert.AreEqual("Task 1 in the list 1 of the project 2", twTimeEntries[0].TaskName);
            Assert.AreEqual(3, twTimeEntries[0].Hours);
            Assert.AreEqual(0, twTimeEntries[0].Minutes);
        }
    }
}
