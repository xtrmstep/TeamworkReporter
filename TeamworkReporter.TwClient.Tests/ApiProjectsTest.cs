using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiProjectTest : ApiTestSetup
    {
        private readonly IProxyProjects _apiProjects;

        public ApiProjectTest()
        {
            _apiProjects = Api;
        }

        [TestCategory("Project API Calls")]
        [TestMethod]
        public void Should_return_all_projects()
        {
            var projects = _apiProjects.Get();

            Assert.IsNotNull(projects);
            var twProjects = projects as TwProject[] ?? projects.ToArray();

            Assert.AreEqual(2, twProjects.Count());
            Assert.AreEqual("Test project 1", twProjects[0].Name); // id = 67094
            Assert.AreEqual("Test project 2", twProjects[1].Name);
        }

        [TestCategory("Project API Calls")]
        [TestMethod]
        public void Should_return_a_single_project()
        {
            var project = _apiProjects.Get(67094);

            Assert.IsNotNull(project);

            Assert.AreEqual(67094, project.Id); 
            Assert.AreEqual("Test project 1", project.Name);
        }
        
    }
}
