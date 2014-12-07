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
            AutoMapperConfig.Start();
            EventMappings.Configure();
            RebusConfig.Start(NinjectWebCommon.Kernel);

            var ninjectResolver = new NinjectDependencyResolver(NinjectWebCommon.Kernel);

            DependencyResolver.SetResolver(ninjectResolver);                        // MVC
            GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver; // Web.API
        }
    }
}