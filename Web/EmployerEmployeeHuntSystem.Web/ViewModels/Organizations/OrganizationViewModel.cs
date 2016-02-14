namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System;
    using Account;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserViewModel Founder { get; set; }

        public DateTime FoundedOn { get; set; }
    }
}
