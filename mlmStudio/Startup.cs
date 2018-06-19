using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mlmStudio.Startup))]
namespace mlmStudio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

