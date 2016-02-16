namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters
{
    using System.Web.Mvc;

    public class HeadhuntersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Headhunters";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Headhunters_default",
                "Headhunters/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers" });
        }
    }
}
