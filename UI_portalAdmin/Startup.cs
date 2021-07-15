using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI_portalAdmin.Startup))]
namespace UI_portalAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
