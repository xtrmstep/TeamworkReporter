using System.Collections.Generic;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient
{
    public interface IProxyTaskLists : IProxy
    {
        /// <summary>
        /// Get all task lists for a project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="showTasks">You can pass showTasks=FALSE if you do not want to have the tasks returned (showTasks defaults to TRUE).</param>
        /// <remarks>Subtasks are not returned (getSubTasks = no)</remarks>
        /// <returns></returns>
        IEnumerable<TwTaskList> Get(int projectId, bool showTasks = true);
    }
}