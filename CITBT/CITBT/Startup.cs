using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CITBT.Startup))]
namespace CITBT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
