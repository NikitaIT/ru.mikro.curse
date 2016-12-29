using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wizitka.Startup))]
namespace Wizitka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
