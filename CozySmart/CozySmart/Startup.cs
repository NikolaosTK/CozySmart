using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CozySmart.Startup))]
namespace CozySmart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
