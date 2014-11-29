using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zen.Imobi.Web.Startup))]
namespace Zen.Imobi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
