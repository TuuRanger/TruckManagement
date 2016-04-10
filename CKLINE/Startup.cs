using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CKLINE.Startup))]
namespace CKLINE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
