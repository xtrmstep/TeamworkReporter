using System.Collections.Generic;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient
{
    public interface IProxyTasks : IProxy
    {
        /// <summary>
        ///     Retrieve all tasks on a task list
        /// </summary>
        /// <param name="taskListId">Task list ID</param>
        /// <returns></returns>
        IEnumerable<TwTask> GetByList(int taskListId);

        /// <summary>
        ///     Retrieve a task
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns></returns>
        TwTask Get(int id);
    }
}