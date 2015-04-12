using System;
using System.Collections.Generic;
using TeamworkReporter.TwClient.Api.Contracts;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient : IProxyTimeTracking
    {
        const string FROM_TIME = "00:00";
        const string TO_TIME = "23:59";
            
        IEnumerable<TwTimeEntry> IProxyTimeTracking.Get()
        {
            var result = Request<TimeEntriesApiRequest>("/time_entries.json");
            return result.TimeEntries;
        }

        IEnumerable<TwTimeEntry> IProxyTimeTracking.Get(DateTime @from, DateTime to)
        {
            var fromdate = @from.Date.ToString("yyyyMMdd");
            var todate = to.Date.ToString("yyyyMMdd");
            var result = Request<TimeEntriesApiRequest>(string.Format("/time_entries.json?fromdate={0}&fromtime={1}&todate={2}&totime={3}", fromdate, FROM_TIME, todate, TO_TIME));
            return result.TimeEntries;
        }

        IEnumerable<TwTimeEntry> IProxyTimeTracking.Get(DateTime @from, DateTime to, int userId)
        {
            var fromdate = @from.Date.ToString("yyyyMMdd");
            var todate = to.Date.ToString("yyyyMMdd");
            var result = Request<TimeEntriesApiRequest>(string.Format("/time_entries.json?fromdate={0}&fromtime={1}&todate={2}&totime={3}&userId={4}", fromdate, FROM_TIME, todate, TO_TIME, userId));
            return result.TimeEntries;
        }

        IEnumerable<TwTimeEntry> IProxyTimeTracking.GetByProject(int projectId)
        {
            var result = Request<TimeEntriesApiRequest>(string.Format("/projects/{0}/time_entries.json", projectId));
            return result.TimeEntries;
        }

        IEnumerable<TwTimeEntry> IProxyTimeTracking.GetByProject(int projectId, DateTime @from, DateTime to)
        {
            var fromdate = @from.Date.ToString("yyyyMMdd");
            var todate = to.Date.ToString("yyyyMMdd");
            var result = Request<TimeEntriesApiRequest>(string.Format("/projects/{0}/time_entries.json?fromdate={1}&fromtime={2}&todate={3}&totime={4}", projectId, fromdate, FROM_TIME, todate, TO_TIME));
            return result.TimeEntries;
        }

        IEnumerable<TwTimeEntry> IProxyTimeTracking.GetByTask(int taskId)
        {
            var result = Request<TimeEntriesApiRequest>(string.Format("/todo_items/{0}/time_entries.json", taskId));
            return result.TimeEntries;
        }
    }
}