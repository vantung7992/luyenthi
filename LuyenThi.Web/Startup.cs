using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LuyenThi.Web.Startup))]
namespace LuyenThi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
