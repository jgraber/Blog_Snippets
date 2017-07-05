using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NDependTechDebt.Startup))]
namespace NDependTechDebt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
