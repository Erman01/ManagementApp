using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkManagement.MVCUI.Startup))]
namespace WorkManagement.MVCUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
