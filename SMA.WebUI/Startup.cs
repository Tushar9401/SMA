using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SMA.WebUI.StartupOwin))]

namespace SMA.WebUI
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
