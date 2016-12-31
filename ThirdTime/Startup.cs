using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThirdTime.Startup))]
namespace ThirdTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
