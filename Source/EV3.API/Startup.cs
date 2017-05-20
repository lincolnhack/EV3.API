using EV3.API;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EV3.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
