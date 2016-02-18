namespace EmployerEmployeeHuntSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using DeveloperProfiles;
    using Organizations;

    public class IndexViewModel
    {
        public IDictionary<string, int> Statistics { get; set; }

        public IEnumerable<DeveloperProfileViewModel> TopDevelopers { get; set; }

        public IEnumerable<OrganizationViewModel> TopOrganizations { get; set; }
    }
}
