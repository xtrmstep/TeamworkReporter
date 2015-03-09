using System.Collections.Generic;
using TeamworkReporter.TwClient.Api.Contracts;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient : IProxyTasks
    {
        IEnumerable<TwTask> IProxyTasks.GetByList(int taskListId)
        {
            var result = Request<TasksApiRequest>(string.Format("/tasklists/{0}/tasks.json", taskListId));
            return result.Tasks;
        }

        TwTask IProxyTasks.Get(int id)
        {
            var result = Request<TaskApiRequest>(string.Format("/tasks/{0}.json", id));
            return result.Task;
        }
    }
}