using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UseIt.Startup))]
namespace UseIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
