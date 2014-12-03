using MvcRouteTester;
using System.Web.Routing;
using Xunit;
using Zen.Imobi.Web;
using Zen.Imobi.Web.Controllers;

namespace Zen.Imobi.Tests
{
    public class RouteTests
    {
        [Fact]
        public void Urls()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            routes.ShouldMap("/home/index").To<HomeController>(x => x.Index());

            routes.ShouldMap("/images/green").To<ImagesController>(x => x.Index("green"));
            routes.ShouldMap("/images/green/1").To<ImagesController>(x => x.Index("green", 1));
        }
    }
}