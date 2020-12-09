using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VueMVC.Startup))]
namespace VueMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
