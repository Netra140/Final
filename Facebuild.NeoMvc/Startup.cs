using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebuild.NeoMvc.Startup))]
namespace Facebuild.NeoMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
