using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ULMS.Startup))]
namespace ULMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
