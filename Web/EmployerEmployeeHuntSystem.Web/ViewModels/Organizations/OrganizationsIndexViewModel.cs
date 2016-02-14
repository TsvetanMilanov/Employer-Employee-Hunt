namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System.Collections.Generic;

    public class OrganizationsIndexViewModel : BaseViewModel
    {
        public ICollection<OrganizationViewModel> Organizations { get; set; }
    }
}
