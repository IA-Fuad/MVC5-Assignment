using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeMVC.Startup))]
namespace PracticeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
