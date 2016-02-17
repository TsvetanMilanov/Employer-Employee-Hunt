namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using ViewModels.Roles;

    public class RolesController : AdministrationBaseController
    {
        private IRolesService roles;

        public RolesController(IRolesService roles)
        {
            this.roles = roles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult AddRoleToUser()
        {
            RoleManagementViewModel model = new RoleManagementViewModel();

            return this.View(model);
        }

        [HttpGet]
        public ActionResult RemoveRoleFromUser()
        {
            RoleManagementViewModel model = new RoleManagementViewModel();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoleToUser(RoleManagementViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.roles.AddRoleToUser(model.UserName, model.Role);

            this.SetTempDataSuccessMessage("Role added to user!");

            return this.RedirectToAction("Index", "Administration", new { area = "Administration" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveRoleFromUser(RoleManagementViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.roles.RemoveRoleFromUser(model.UserName, model.Role);

            this.SetTempDataSuccessMessage("Role removed from user!");

            return this.RedirectToAction("Index", "Administration", new { area = "Administration" });
        }

        [HttpGet]
        public ActionResult Names(string filter)
        {
            return this.Json(this.roles.GetRolesNamesByFilter(filter).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
