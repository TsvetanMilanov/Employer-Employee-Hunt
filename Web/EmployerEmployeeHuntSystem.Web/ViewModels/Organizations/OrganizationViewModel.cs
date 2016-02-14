namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System;
    using System.Linq;
    using Account;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserViewModel Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        public int JobOffersCount { get; set; }

        public virtual void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationViewModel>()
                .ForMember(m => m.JobOffersCount, opts => opts.MapFrom(o => o.JobOffers.Where(j => j.IsDeleted == false && j.IsActive == true).ToList().Count));
        }
    }
}
