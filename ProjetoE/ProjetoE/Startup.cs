using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoE.Startup))]
namespace ProjetoE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
