using System;
using System.Collections.Generic;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient
{
    public interface IProxyTimeTracking : IProxy
    {
        /// <summary>
        ///     Retrieve All time Entries across all projects
        /// </summary>
        /// <returns></returns>
        IEnumerable<TwTimeEntry> Get();

        /// <summary>
        ///     Retrieve All time Entries across all projects
        /// </summary>
        /// <param name="from">The start date/time to retrieve from</param>
        /// <param name="to">The end date/time to retrieve to</param>
        /// <returns></returns>
        IEnumerable<TwTimeEntry> Get(DateTime from, DateTime to);

        /// <summary>
        ///     Retrieve all time entries for a project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <returns></returns>
        IEnumerable<TwTimeEntry> GetByProject(int projectId);

        /// <summary>
        ///     Retrieve all time entries for a project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="from">The start date/time to retrieve from</param>
        /// <param name="to">The end date/time to retrieve to</param>
        /// <returns></returns>
        IEnumerable<TwTimeEntry> GetByProject(int projectId, DateTime from, DateTime to);


        /// <summary>
        ///     Retrieve all task time entries
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <returns></returns>
        IEnumerable<TwTimeEntry> GetByTask(int taskId);
    }
}