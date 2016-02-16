namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters
{
    using System.Web.Mvc;

    public class HeadhunterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Headhunter";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Headhunter_default",
                "Headhunter/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
