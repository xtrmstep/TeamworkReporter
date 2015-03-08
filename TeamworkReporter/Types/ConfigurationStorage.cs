using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TeamworkReporter.Types
{
    public class ConfigurationStorage
    {
        private readonly string storageFilePath;
        /// <summary>
        /// Create a file storage for configuration
        /// </summary>
        /// <param name="filePath"></param>
        public ConfigurationStorage(string filePath)
        {
            storageFilePath = filePath;
        }

        public void Save(Configuration configuration)
        {
            var bf = new BinaryFormatter();
            using (var fs = File.OpenWrite(storageFilePath))
            {
                bf.Serialize(fs, configuration);
            }
        }

        public Configuration Load()
        {
            Configuration configuration;

            if (File.Exists(storageFilePath) == false)
                return new Configuration();

            var fileData = File.ReadAllBytes(storageFilePath);
            if (fileData.Length == 0)
                return new Configuration();

            var bf = new BinaryFormatter();
            using (var fs = File.OpenRead(storageFilePath))
            {
                configuration = bf.Deserialize(fs) as Configuration;
            }
            return configuration;
        }
    }
}