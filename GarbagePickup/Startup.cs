using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GarbagePickup.Startup))]
namespace GarbagePickup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
