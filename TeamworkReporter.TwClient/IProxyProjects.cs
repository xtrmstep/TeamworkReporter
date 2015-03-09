using System.Collections.Generic;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient
{
    /// <summary>
    /// Projects API Calls (http://developer.teamwork.com/projectsapi)
    /// </summary>
    public interface IProxyProjects : IProxy
    {
        /// <summary>
        ///     Retrieves all accessible projects. Default returns your active projects
        /// </summary>
        /// <returns></returns>
        IEnumerable<TwProject> Get();

        /// <summary>
        ///     Returns a single project identified by its integer ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        TwProject Get(int projectId);
    }
}