using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataCollector.Mvc.Startup))]
namespace DataCollector.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
