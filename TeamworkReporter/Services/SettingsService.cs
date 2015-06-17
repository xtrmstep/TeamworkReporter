using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TeamworkReporter.Services.Configuration;

namespace TeamworkReporter.Services
{
    public class SettingsService : ISettingsService
    {
        public string ConnectionString
        {
            get
            {
                var key = Get<string>("TeamworkReporterDB");
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
        }

        internal T Get<T>(string appSettingKey)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[appSettingKey], typeof(T));
        }
    }
}