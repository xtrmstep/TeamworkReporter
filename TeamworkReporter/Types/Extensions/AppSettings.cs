using System.Web.Configuration;

namespace TeamworkReporter.Types.Extensions
{
    public static class AppSettings
    {
        public static string ConfigFile()
        {
            return WebConfigurationManager.AppSettings["ConfigFile"];
        }
    }
}