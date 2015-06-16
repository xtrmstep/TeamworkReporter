using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamworkReporter.Types.Tests
{
    [TestClass]
    public class ConfigurationStorageTests
    {
        private const string FILE_NAME = "config.cfg";
        private static string filePath;

        [ClassInitialize]
        public static void TestSuiteSetup(TestContext context)
        {
            filePath = context.TestDeploymentDir + "\\" + FILE_NAME;
        }

        [TestInitialize]
        public void TestSetup()
        {
            File.Delete(filePath);
        }

        [TestMethod]
        public void Save_should_store_configuration_to_a_new_file()
        {
            Assert.IsFalse(File.Exists(filePath), "File should not be existed");
            var configuration = new Configuration {Account = "account", Token = "token"};
            var storage = new ConfigurationStorage(filePath);
            storage.Save(configuration);

            Assert.IsTrue(File.Exists(filePath), "File should be existed");
            var fileData = File.ReadAllBytes(filePath);
            Assert.IsTrue(fileData != null && fileData.Length > 0, "File should not be empty");
        }

        [TestMethod]
        public void Save_should_store_configuration_to_an_existing_file()
        {
            File.Create(filePath).Close();
            var lastModification = File.GetLastWriteTimeUtc(filePath);
            // saving of the file wondoes not happen very quickly
            // without this delay file is modified too quickly and time difference cannot be taken
            Thread.Sleep(10); 

            var configuration = new Configuration {Account = "account", Token = "token"};
            var storage = new ConfigurationStorage(filePath);
            storage.Save(configuration);

            var anotherLastModification = File.GetLastWriteTimeUtc(filePath);
            Assert.IsTrue(DateTime.Compare(anotherLastModification, lastModification) > 0, "Last modification date should be greater after configuration is saved");
        }

        [TestMethod]
        public void Load_should_restore_configuration_from_a_file()
        {
            var configuration = new Configuration {Account = "account", Token = "token"};
            var storage = new ConfigurationStorage(filePath);
            storage.Save(configuration);

            var storage2 = new ConfigurationStorage(filePath);
            var configuration2 = storage2.Load();

            Assert.AreEqual(configuration.Account, configuration2.Account);
            Assert.AreEqual(configuration.Token, configuration2.Token);
        }

        [TestMethod]
        public void Load_should_restore_empty_configuration_from_an_empty_file()
        {
            File.Create(filePath).Close();

            var storage = new ConfigurationStorage(filePath);
            var configuration = storage.Load();

            Assert.IsTrue(configuration.Account == string.Empty);
            Assert.IsTrue(configuration.Token == string.Empty);
        }

        [TestMethod]
        public void Load_should_restore_empty_configuration_from_an_nonExisted_file()
        {
            Assert.IsFalse(File.Exists(filePath), "File should not exist");

            var storage = new ConfigurationStorage(filePath);
            var configuration = storage.Load();

            Assert.IsTrue(configuration.Account == string.Empty);
            Assert.IsTrue(configuration.Token == string.Empty);
        }
    }
}