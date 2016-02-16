namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters
{
    using System.Web.Mvc;

    public class HeadhunterAreaRegistration : AreaRegistration
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
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
