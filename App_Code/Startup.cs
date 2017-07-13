using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gs_newsletter.Startup))]
namespace gs_newsletter
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
