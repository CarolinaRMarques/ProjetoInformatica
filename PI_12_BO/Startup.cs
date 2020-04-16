using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PI_12_BO.Startup))]
namespace PI_12_BO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
