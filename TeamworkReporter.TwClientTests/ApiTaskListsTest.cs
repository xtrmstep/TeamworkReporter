using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;
using TeamworkReporter.TwClient.Data;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiTaskListsTest : ApiTestSetup
    {
        private readonly IProxyTaskLists _apiTaskLists;

        public ApiTaskListsTest()
        {
            _apiTaskLists = Api;
        }

        [TestCategory("Task Lists API Calls")]
        [TestMethod]
        public void Should_return_all_task_lists_with_tasks()
        {
            var taskLists = _apiTaskLists.Get(67094);

            var twTaskLists = CheckTaskLists(taskLists);

            var tasks = twTaskLists[0].Tasks;
            Assert.IsNotNull(tasks);
            var twTasks = tasks as TwTask[] ?? tasks.ToArray();
            Assert.AreEqual(1, twTasks.Count());
            Assert.AreEqual("Task 1 in the list 2 of the project 1", twTasks.First().Content); // id = 192462
        }

        [TestCategory("Task Lists API Calls")]
        [TestMethod]
        public void Should_return_all_task_lists_without_tasks()
        {
            var taskLists = _apiTaskLists.Get(67094, false);

            var twTaskLists = CheckTaskLists(taskLists);
            var tasks = twTaskLists[0].Tasks;
            Assert.IsNull(tasks);
        }

        private static TwTaskList[] CheckTaskLists(IEnumerable<TwTaskList> taskLists)
        {
            Assert.IsNotNull(taskLists);
            var twTaskLists = taskLists as TwTaskList[] ?? taskLists.ToArray();

            Assert.AreEqual(2, twTaskLists.Count());
            Assert.AreEqual("Tasks list 2 in the project 1", twTaskLists[0].Name); // id = 192462
            Assert.AreEqual("Tasks list 1 in the project 1", twTaskLists[1].Name); // id = 192461

            return twTaskLists;
        }
        
    }
}
