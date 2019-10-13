using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoFocus_CodeFirst.Startup))]
namespace AutoFocus_CodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
