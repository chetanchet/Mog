using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mog.Startup))]
namespace Mog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
