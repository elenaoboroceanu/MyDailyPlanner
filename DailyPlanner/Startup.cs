using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DailyPlanner.Startup))]
namespace DailyPlanner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
