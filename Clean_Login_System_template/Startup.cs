using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Clean_Login_System_template.Startup))]
namespace Clean_Login_System_template
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
