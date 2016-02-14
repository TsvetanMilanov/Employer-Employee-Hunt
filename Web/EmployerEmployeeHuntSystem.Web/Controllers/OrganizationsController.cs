namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Organizations;

    public class OrganizationsController : BaseController
    {
        private IOrganizationsService organizations;

        public OrganizationsController(IOrganizationsService organizations)
        {
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            OrganizationsIndexViewModel model = new OrganizationsIndexViewModel();

            var allOrganizations = this.organizations.GetAll();

            model.Organizations = allOrganizations.To<OrganizationViewModel>().ToList();

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            OrganizationDetailsViewModel model = this.Mapper.Map<OrganizationDetailsViewModel>(this.organizations.GetById(id));
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

            Organization organization = this.organizations.Create(model.Name, model.CurrentUser.Id, DateTime.Now);

            this.TempData[GlobalConstants.SuccessMessageTempDataKey] = string.Format("Organization {0} successfully created!", organization.Name);

            return this.RedirectToAction("Details", new { id = organization.Id });
        }
    }
}
