using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TeamworkReporter.Types;
using TeamworkReporter.Types.Extensions;

namespace TeamworkReporter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            var configFile = AppSettings.ConfigFile();
            Settings.Storage = new ConfigurationStorage(Server.MapPath(configFile));
            Settings.Config = Settings.Storage.Load();
        }
    }
}
