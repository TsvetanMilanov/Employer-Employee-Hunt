namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
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
    }
}
