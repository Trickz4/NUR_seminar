using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NUR_seminar.Startup))]
namespace NUR_seminar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
