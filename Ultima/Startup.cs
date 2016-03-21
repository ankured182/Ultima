using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ultima.Startup))]
namespace Ultima
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
