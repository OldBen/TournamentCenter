using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TounamentCenter.Startup))]
namespace TounamentCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
