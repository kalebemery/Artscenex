using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Artsy.WebMVC.Startup))]
namespace Artsy.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
