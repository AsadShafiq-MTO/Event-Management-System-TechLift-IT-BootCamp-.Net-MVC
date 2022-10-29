using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Event_Management_System_BootCamp.Startup))]
namespace Event_Management_System_BootCamp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
