using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookley.Startup))]
namespace Bookley
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
