namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System;
    using System.Collections.Generic;
    using Account;
    using Data.Models;
    using Infrastructure.Mapping;
    using JobOffers;

    public class OrganizationDetailsViewModel : BaseViewModel, IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserViewModel Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        public ICollection<JobOfferViewModel> JobOffers { get; set; }
    }
}
