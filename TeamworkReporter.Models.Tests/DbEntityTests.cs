using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.Models;

namespace TeamworkReporter.ModelsTests
{
    [TestClass]
    public class DbEntityTests
    {
        class FakeDbEntity : DbEntity
        {
            // it's used for tests
        }

        [TestMethod]
        public void CreatedDate_shouldBe_initialized()
        {
            var now = DateTimeOffset.Now;
            Thread.Sleep(2); // wait for a moment to make sure the order is correct

            // when the object is created the property CreatedDate must be set to Now
            // the property value should be later than the field 'now' value
            var entity = new FakeDbEntity();
            Assert.IsTrue(entity.CreatedDate > now, "CreateDate should be initialized from DateTimeOffset.Now in constructor");
        }
    }
}
