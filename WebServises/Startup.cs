using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebServises.Startup))]
namespace WebServises
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
