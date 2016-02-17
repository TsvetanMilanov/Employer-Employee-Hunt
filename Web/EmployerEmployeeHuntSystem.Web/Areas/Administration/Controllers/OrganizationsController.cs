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
    }
}
