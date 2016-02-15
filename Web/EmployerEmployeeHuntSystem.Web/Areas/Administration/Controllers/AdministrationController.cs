namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Web.ViewModels;

    public class AdministrationController : AdministrationBaseController
    {
        public ActionResult Index()
        {
            return this.View(new BaseViewModel());
        }
    }
}
