namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System.Collections.Generic;

    public class OrganizationsIndexViewModel : BaseViewModel
    {
        public IEnumerable<OrganizationViewModel> Organizations { get; set; }
    }
}
