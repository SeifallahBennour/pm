using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Present.Startup))]
namespace Present
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
