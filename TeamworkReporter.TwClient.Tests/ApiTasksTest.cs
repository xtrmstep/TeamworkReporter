using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiTasksTest : ApiTestSetup
    {
        private readonly IProxyTasks _apiTasks;

        public ApiTasksTest()
        {
            _apiTasks = Api;
        }

        [TestCategory("Tasks API Calls")]
        [TestMethod]
        public void Should_return_all_tasks_by_taskList()
        {
            var tasks = _apiTasks.GetByList(192462);

            Assert.IsNotNull(tasks);
            var twTasks = tasks as TwTask[] ?? tasks.ToArray();

            Assert.AreEqual(1, twTasks.Count());
            Assert.AreEqual("Task 1 in the list 2 of the project 1", twTasks[0].Content); 
        }

        [TestCategory("Tasks API Calls")]
        [TestMethod]
        public void Should_return_a_single_task()
        {
            var task = _apiTasks.Get(1255800);

            Assert.IsNotNull(task);

            Assert.AreEqual(1255800, task.Id);
            Assert.AreEqual("Task 1 in the list 1 of the project 1", task.Content);
        }
        
    }
}
