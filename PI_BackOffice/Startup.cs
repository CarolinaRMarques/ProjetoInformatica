using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PI_BackOffice.Startup))]
namespace PI_BackOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
