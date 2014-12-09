using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFishEye.WebConsole.Startup))]
namespace MyFishEye.WebConsole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
