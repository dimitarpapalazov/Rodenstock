using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rodenstock.Startup))]
namespace Rodenstock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
