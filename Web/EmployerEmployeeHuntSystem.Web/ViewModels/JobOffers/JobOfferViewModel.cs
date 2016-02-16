namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Skills;

    public class JobOfferViewModel : IMapFrom<JobOffer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Organization { get; set; }

        [Range(DatabaseConstants.MinCanditatesForJobOffer, int.MaxValue)]
        public int MinimumCandidatesCount { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<SkillViewModel> RequiredSkills { get; set; }

        public int CandidatesCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<JobOffer, JobOfferViewModel>()
                .ForMember(m => m.Organization, opts => opts.MapFrom(j => j.Organization.Name))
                .ForMember(m => m.CandidatesCount, opts => opts.MapFrom(j => j.Candidacies.Count))
                .ForMember(m => m.OrganizationId, opts => opts.MapFrom(j => j.Organization.Id));
        }
    }
}
