using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reminder.WebMVC.Startup))]
namespace Reminder.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
