using System.Collections.Generic;
using TeamworkReporter.TwClient.Api;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient
{
    /// <summary>
    /// People API Calls (http://developer.teamwork.com/people)
    /// </summary>
    public interface IProxyPeople : IProxy
    {
        /// <summary>
        /// All people visible to the user will be returned, including the user themselves
        /// </summary>
        /// <remarks>
        /// By default 200 records are returned at a time. You can specify page settings by means of parameter
        /// </remarks>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TwPerson> Get(PageInfo page = null);

        /// <summary>
        /// Retrieves the user details for the ID submitted
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        TwPerson Get(int personId);

        /// <summary>
        /// Retrieves all of the people in a given project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        IEnumerable<TwPerson> GetByProject(int projectId);

        /// <summary>
        /// Retrieves ID list for all the people from the submitted company (excluding those you don't have permission to see)
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IEnumerable<TwPerson> GetByCompany(int companyId);
    }
}