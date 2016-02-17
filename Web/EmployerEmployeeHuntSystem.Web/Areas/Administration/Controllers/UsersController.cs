namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Users;

    public class UsersController : AdministrationBaseController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var model = this.users.GetAll().To<UserAdministrationViewModel>().ToList();

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Names(string filter)
        {
            return this.Json(this.users.GetUsersUserNames(filter).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction("Index");
            }

            var model = this.Mapper.Map<UserAdministrationViewModel>(this.users.GetById(id));

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserAdministrationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.users.Edit(model.Id, model.Email, model.UserName, model.PhoneNumber);

            this.SetTempDataSuccessMessage("User edited successfully!");

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.RedirectToAction("Index");
            }

            // TODO: Fix the cascade delete problem.
            // this.users.Delete(id);
            // this.SetTempDataSuccessMessage("The user was deleted successfully!");
            this.SetTempDataErrorMessage("The user cannot be deletet right now.");

            return this.RedirectToAction("Index");
        }
    }
}
