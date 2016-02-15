namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunter.Controllers
{
    using System.Web.Mvc;

    public class HeadhuntersController : HeadhuntersBaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
