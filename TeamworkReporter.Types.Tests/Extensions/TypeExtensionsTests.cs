using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.Types.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TeamworkReporter.Types.Extensions.Tests
{
    [TestClass]
    public class TypeExtensionsTests
    {
        [TestMethod]
        public void GetKeyProperties_should_return_property_by_attribute()
        {
            var pr = typeof(EntityWithKey).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(1, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_all_property_by_attribute()
        {
            var pr = typeof(EntityWithTwoKeys).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(2, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_property_by_match()
        {
            var pr = typeof(EntityWithSymbolicKey).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(1, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_all_property_by_match()
        {
            var pr = typeof(EntityWithTwoSymbolicKey).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(2, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_all_property_when_mixed()
        {
            var pr = typeof(EntityWithMixedKey).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(2, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_not_return_same_property_twice_by_attr_and_match()
        {
            var pr = typeof(EntityWithTwoKeys).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(2, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_empty()
        {
            var pr = typeof(EntityWithoutKey).GetKeyProperties();
            Assert.IsNotNull(pr);
            Assert.AreEqual(0, pr.Length);
        }

        [TestMethod]
        public void GetKeyProperties_should_return_null()
        {
            Type t = null;
            var pr = t.GetKeyProperties();
            Assert.IsNull(pr);
        }
        //todo !!! separate test classes from the tests
        public class EntityWithKey
        {
            [Key]
            public int Id { get; set; }

            public int Value { get; set; }
        }

        public class EntityWithSymbolicKey
        {
            public int Id { get; set; }

            public int Value { get; set; }
        }

        public class EntityWithTwoKeys
        {
            [Key]
            public int Id { get; set; }

            [Key]
            public int Rank { get; set; }

            public int Value { get; set; }
        }

        public class EntityWithTwoSymbolicKey
        {
            public int Id { get; set; }

            public int RankId { get; set; }

            public int Value { get; set; }
        }

        public class EntityWithMixedKey
        {
            public int Id { get; set; }

            [Key]
            public int Rank { get; set; }

            public int Value { get; set; }
        }

        public class EntityWithoutKey
        {
            public int Value { get; set; }
        }
    }
}