namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunter.Controllers
{
    using System.Web.Mvc;
    using ViewModels;

    public class JobOffersController : HeadhuntersBaseController
    {
        public ActionResult Current()
        {
            return this.View(new BaseViewModel());
        }
    }
}
