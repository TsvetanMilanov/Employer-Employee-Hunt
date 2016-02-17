namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Organizations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationAdministrationEditViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        [MinLength(DatabaseConstants.MinOrganizationNameLength)]
        [MaxLength(DatabaseConstants.MaxOrganizationNameLength)]
        [Required]
        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationAdministrationEditViewModel>()
                .ForMember(m => m.Founder, opts => opts.MapFrom(o => o.Founder.Email));
        }
    }
}
