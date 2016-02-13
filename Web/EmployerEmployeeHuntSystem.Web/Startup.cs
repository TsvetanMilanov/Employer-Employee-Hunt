using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(EmployerEmployeeHuntSystem.Web.Startup))]

namespace EmployerEmployeeHuntSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
