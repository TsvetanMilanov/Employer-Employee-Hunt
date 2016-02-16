namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Web.Mvc;
    using Web.ViewModels;

    public class HeadhuntersController : HeadhuntersBaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
