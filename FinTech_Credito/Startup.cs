using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dashboard_Bajas_Carrier.Startup))]
namespace Dashboard_Bajas_Carrier
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
