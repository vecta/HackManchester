using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kitbag.HackWebApplication.Startup))]
namespace Kitbag.HackWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
