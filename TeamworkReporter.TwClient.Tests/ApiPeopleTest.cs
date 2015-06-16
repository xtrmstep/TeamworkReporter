using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.TwClient;
using TeamworkReporter.TwClient.Api;

namespace TeamworkReporter.TwClientTests
{
    [TestClass]
    public class ApiPeopleTest : ApiTestSetup
    {
        private readonly IProxyPeople _apiPeople;

        public ApiPeopleTest()
        {
            _apiPeople = Api;
        }

        [TestCategory("People API Calls")]
        [TestMethod]
        public void Should_return_all_people()
        {
            var people = _apiPeople.Get();
            
            Assert.IsNotNull(people);
            var persons = people.OrderBy(p => p.FirstName).ToArray();
            Assert.AreEqual(3, persons.Length);
            
            var thePerson = persons[0];
            Assert.AreEqual("TestFirst1", thePerson.FirstName);
            Assert.AreEqual("TestLast1", thePerson.LastName);
            Assert.AreEqual("test97038f2299e84fccb756daf252c99bb9@mail.ru", thePerson.Email);

            thePerson = persons[1];
            Assert.AreEqual("TestFirst2", thePerson.FirstName);
            Assert.AreEqual("TestLast2", thePerson.LastName);
            Assert.AreEqual("test2011d91dda2e4215970b578c7ba95245@mail.ru", thePerson.Email);

            thePerson = persons[2];
            Assert.AreEqual("Tw", thePerson.FirstName);
            Assert.AreEqual("Reporter", thePerson.LastName);
            Assert.AreEqual("twreporter@mail.ru", thePerson.Email);
        }

        [TestCategory("People API Calls")]
        [TestMethod]
        public void Should_return_a_page_of_people()
        {
            var people = _apiPeople.Get(new PageInfo{Page = 1, PageSize = 1});

            Assert.IsNotNull(people);
            var persons = people.OrderBy(p => p.FirstName).ToArray();
            Assert.AreEqual(1, persons.Length);

            var thePerson = persons[0];
            Assert.AreEqual("TestFirst1", thePerson.FirstName);
            Assert.AreEqual("TestLast1", thePerson.LastName);
            Assert.AreEqual("test97038f2299e84fccb756daf252c99bb9@mail.ru", thePerson.Email);
        }

        [TestCategory("People API Calls")]
        [TestMethod]
        public void Should_return_a_single_person()
        {
            var person = _apiPeople.Get(71902);
            Assert.IsNotNull(person);

            Assert.AreEqual("TestFirst1", person.FirstName);
            Assert.AreEqual("TestLast1", person.LastName);
            Assert.AreEqual("test97038f2299e84fccb756daf252c99bb9@mail.ru", person.Email);
        }

        [TestCategory("People API Calls")]
        [TestMethod]
        public void Should_return_people_of_project()
        {
            var people = _apiPeople.GetByProject(67099);

            Assert.IsNotNull(people);
            var persons = people.OrderBy(p => p.FirstName).ToArray();
            Assert.AreEqual(2, persons.Length);

            var thePerson = persons[0];
            Assert.AreEqual("TestFirst1", thePerson.FirstName);
            Assert.AreEqual("TestLast1", thePerson.LastName);
            Assert.AreEqual("test97038f2299e84fccb756daf252c99bb9@mail.ru", thePerson.Email);

            thePerson = persons[1];
            Assert.AreEqual("Tw", thePerson.FirstName);
            Assert.AreEqual("Reporter", thePerson.LastName);
            Assert.AreEqual("twreporter@mail.ru", thePerson.Email);
        }

        [TestCategory("People API Calls")]
        [TestMethod]
        public void Should_return_people_of_company()
        {
            var people = _apiPeople.GetByCompany(35730);

            Assert.IsNotNull(people);
            var persons = people.OrderBy(p => p.FirstName).ToArray();
            Assert.AreEqual(1, persons.Length);

            var thePerson = _apiPeople.Get(persons[0].Id);
            Assert.IsNotNull(thePerson);

            Assert.AreEqual("TestFirst2", thePerson.FirstName);
            Assert.AreEqual("TestLast2", thePerson.LastName);
            Assert.AreEqual("test2011d91dda2e4215970b578c7ba95245@mail.ru", thePerson.Email);
        }

    }
}
