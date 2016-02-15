namespace EmployerEmployeeHuntSystem.Web.Areas.Administration
{
    using System.Web.Mvc;

    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administration_api",
                "api/Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });

            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
