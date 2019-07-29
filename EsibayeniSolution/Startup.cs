using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsibayeniSolution.Startup))]
namespace EsibayeniSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
