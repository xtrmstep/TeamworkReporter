using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TeamworkReporter.Services.Configuration;
using TeamworkReporter.Services.Permissions;
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

            #region Autofac configuration

            //todo issue with WebMatrix reference: cannot load (if add DataContext)

            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //builder.Register(c => new SettingsService()).As<ISettingsService>().InstancePerRequest();
            //builder.Register(c => new TwrDbContext(c.Resolve<ISettingsService>().ConnectionString)).As<DbContext>().InstancePerRequest();
            //builder.RegisterType<SecurityService>().As<ISecurityService>().InstancePerRequest();
            //builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();
            
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion

        }

        protected void Application_BeginRequest()
        {
            var configFile = AppSettings.ConfigFile();
            Settings.Storage = new ConfigurationStorage(Server.MapPath(configFile));
            Settings.Config = Settings.Storage.Load();
        }
    }
}
