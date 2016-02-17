namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Organizations;

    [Authorize]
    public class OrganizationsController : BaseController
    {
        private IOrganizationsService organizations;

        public OrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            OrganizationsIndexViewModel model = new OrganizationsIndexViewModel();

            var allOrganizations = this.organizations.GetAll();

            model.Organizations = allOrganizations.To<OrganizationViewModel>()
                .OrderByDescending(o => o.JobOffersCount)
                .ToList();

            return this.View(model);
        }

        public ActionResult My()
        {
            OrganizationsIndexViewModel model = new OrganizationsIndexViewModel();

            var allOrganizations = this.organizations.GetByFounderId(this.User.Identity.GetUserId());

            model.Organizations = allOrganizations.To<OrganizationViewModel>()
                .OrderByDescending(o => o.JobOffersCount)
                .ToList();

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            Organization organization = this.organizations.GetById(id);

            organization.JobOffers = organization.JobOffers.Where(j => j.IsActive == true && j.IsDeleted == false).ToList();

            OrganizationDetailsViewModel model = this.Mapper.Map<OrganizationDetailsViewModel>(organization);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateOrganizationViewModel model = new CreateOrganizationViewModel();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrganizationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Organization organization = this.organizations.Create(model.Name, this.User.Identity.GetUserId(), DateTime.Now);

            this.SetTempDataSuccessMessage(string.Format("Organization {0} successfully created!", organization.Name));

            return this.RedirectToAction("Details", new { id = organization.Id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditOrganizationViewModel model = this.Mapper.Map<EditOrganizationViewModel>(this.organizations.GetById(id));

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditOrganizationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Organization organization = this.organizations.Edit(model.Id, model.Name);

            this.SetTempDataSuccessMessage("Organization edited successfully.");

            return this.RedirectToAction("Details", new { organizationId = model.Id });
        }

        public ActionResult Delete(int id)
        {
            this.organizations.Delete(id);

            this.SetTempDataSuccessMessage("Organization deleted successfully.");

            return this.RedirectToAction("Index");
        }
    }
}
