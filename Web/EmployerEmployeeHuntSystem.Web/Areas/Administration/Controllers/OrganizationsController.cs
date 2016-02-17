namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Organizations;

    public class OrganizationsController : AdministrationBaseController
    {
        private IOrganizationsService organizations;

        public OrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var model = this.organizations.GetAll()
                .To<OrganizationAdministrationViewModel>().ToList();

            return this.View(model);
        }

        public ActionResult Deleted()
        {
            var model = this.organizations.GetAllWithDeleted()
                .Where(o => o.IsDeleted == true)
                .To<OrganizationAdministrationViewModel>().ToList();

            return this.View(model);
        }

        public ActionResult Restore(int id)
        {
            this.organizations.Restore(id);

            this.SetTempDataSuccessMessage("The organization was restored");

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var organization = this.organizations.GetById(id);

            var model = this.Mapper.Map<OrganizationAdministrationEditViewModel>(organization);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrganizationAdministrationEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.organizations.Edit(model.Id, model.Name, model.FoundedOn, model.Founder);

            this.SetTempDataSuccessMessage("Organization edited successfully!");

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.organizations.Delete(id);

            this.SetTempDataSuccessMessage("Organization deleted successfully!");

            return this.RedirectToAction("Index");
        }
    }
}
