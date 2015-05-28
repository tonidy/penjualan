using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Penjualan.Startup))]
namespace Penjualan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
