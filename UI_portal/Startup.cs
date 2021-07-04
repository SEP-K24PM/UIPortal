using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UI_portal.Startup))]
namespace UI_portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
