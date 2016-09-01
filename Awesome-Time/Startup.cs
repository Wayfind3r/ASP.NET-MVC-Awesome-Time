using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Awesome_Time.Startup))]
namespace Awesome_Time
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
