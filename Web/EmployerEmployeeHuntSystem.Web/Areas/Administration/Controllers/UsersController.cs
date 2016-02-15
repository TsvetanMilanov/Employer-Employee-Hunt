namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class UsersController : AdministrationBaseController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Names(string filter)
        {
            return this.Json(this.users.GetUsersUserNames(filter).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
