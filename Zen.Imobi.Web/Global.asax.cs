using log4net.Config;
using Ninject.Web.Mvc;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Zen.Imobi.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/log4net.config")));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var ninjectResolver = new NinjectDependencyResolver(NinjectWebCommon.Kernel);
            DependencyResolver.SetResolver(ninjectResolver);                        // MVC
            // todo: this needs to be fixed for the Web.API injection to work
            //GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver; // Web.API

            // NOTE: add all application specific configs in this class
            ApplicationConfig.Start();
        }
    }
}