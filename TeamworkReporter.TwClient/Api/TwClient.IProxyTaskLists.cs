using System.Collections.Generic;
using TeamworkReporter.TwClient.Api.Contracts;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient : IProxyTaskLists
    {
        IEnumerable<TwTaskList> IProxyTaskLists.Get(int projectId, bool showTasks)
        {
            var result = Request<TaskListsApiRequest>(string.Format("/projects/{0}/todo_lists.json?showTasks={1}", projectId, showTasks ? "yes" : "no"));
            return result.TaskLists;
        }
    }
}