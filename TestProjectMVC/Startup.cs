using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestProjectMVC.Startup))]
namespace TestProjectMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
