using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnapecCaf.Startup))]
namespace UnapecCaf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
