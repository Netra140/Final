using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebuild.WebMVC.Startup))]
namespace Facebuild.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
