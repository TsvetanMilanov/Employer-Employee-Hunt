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
            var model = this.roles.GetAll().Select(r => new RoleViewModel { Name = r.Name }).ToList();

            return this.View(model);
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

        [HttpGet]
        public ActionResult Add()
        {
            return this.View(new RoleViewModel { Name = string.Empty });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RoleViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.roles.Add(model.Name);

            this.SetTempDataSuccessMessage(string.Format("The role {0} was added successfully!", model.Name));

            return this.RedirectToAction("Index", "Roles");
        }

        [HttpGet]
        public ActionResult Remove(string name)
        {
            this.roles.Remove(name);

            this.SetTempDataSuccessMessage(string.Format("The role {0} was removed successfully!", name));

            return this.RedirectToAction("Index", "Roles");
        }
    }
}
