using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkReporter.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamworkReporter.Models;
using System.Reflection;

namespace TeamworkReporter.DataContext.Tests
{
    [TestClass]
    public class TwReporterContextTests
    {
        [TestMethod]
        public void Verify_notStoredIdValue()
        {
            Assert.AreEqual(TwReporterContext.NotStoredId, new Guid("00000001-0002-0003-0004-000000000005"));
        }

        [TestMethod]
        public void Verify_DataContext_hasAllEntitySets()
        {
            var entityTypes = GetEntityTypes();
            var entityProperties = GetDbSetProperties();

            foreach (var entityType in entityTypes)
            {
                if (!entityProperties.Any(p => p.PropertyType.GetGenericArguments()[0] == entityType))
                    Assert.Fail("The type '{0}' has no corresponding DbSet<T> property.", entityType.Name);
            }
        }

        [TestMethod]
        public void Verify_DataContext_hasOnlyDbEntities()
        {
            var entityProperties = GetDbSetProperties();
            foreach (var entityProperty in entityProperties)
            {
                var entityType = entityProperty.PropertyType.GetGenericArguments()[0];
                var entityBaseType = typeof(DbEntity);
                if (entityType.IsSubclassOf(entityBaseType) == false)
                    Assert.Fail("The entity type of the property 'DbSet<{0}> {1}' is not derived from '{2}'.", entityType.Name, entityProperty.Name, entityBaseType.Name);
            }
        }

        [TestMethod]
        public void Verify_DataContext_hasOnlyOne_dbSetForEntity()
        {
            var entityTypes = GetEntityTypes();
            var entityProperties = GetDbSetProperties();
            foreach (var entityType in entityTypes)
            {
                var props = entityProperties.Where(p => p.PropertyType.GetGenericArguments()[0] == entityType);
                if (props.Count() > 1)
                    Assert.Fail("The entity type '{0}' has more than one DbSet ('{1}').", entityType.Name, props.Select(p => p.Name).Aggregate((a, b) => a + "', '" + b));
            }
        }

        private static PropertyInfo[] GetDbSetProperties()
        {
            return typeof(TwReporterContext).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.PropertyType.IsGenericType).ToArray();
        }

        private static Type[] GetEntityTypes()
        {
            var modelsAssembly = typeof(DbEntity).Assembly;
            var exportedTypes = modelsAssembly.GetExportedTypes();
            var entityTypes = exportedTypes.Where(t => t.IsSubclassOf(typeof(DbEntity))).ToArray();
            return entityTypes;
        }
    }
}
