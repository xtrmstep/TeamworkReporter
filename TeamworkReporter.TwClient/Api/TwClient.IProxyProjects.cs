using System.Collections.Generic;
using TeamworkReporter.TwClient.Api.Contracts;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClient.Api
{
    public partial class TwClient : IProxyProjects
    {
        IEnumerable<TwProject> IProxyProjects.Get()
        {
            var result = Request<ProjectsApiRequest>("/projects.json");
            return result.Projects;
        }

        TwProject IProxyProjects.Get(int projectId)
        {
            var result = Request<ProjectApiRequest>(string.Format("/projects/{0}.json", projectId));
            return result.Project;
        }
    }
}