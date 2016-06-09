using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TournamentCenter.Startup))]
namespace TournamentCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
