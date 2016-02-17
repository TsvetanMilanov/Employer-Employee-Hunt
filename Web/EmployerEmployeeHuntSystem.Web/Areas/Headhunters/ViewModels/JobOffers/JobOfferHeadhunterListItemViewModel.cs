namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.ViewModels.JobOffers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels.Skills;

    public class JobOfferHeadhunterListItemViewModel : IMapFrom<JobOffer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Organization { get; set; }

        [Range(DatabaseConstants.MinCanditatesForJobOffer, int.MaxValue)]
        public int MinimumCandidatesCount { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<SkillViewModel> RequiredSkills { get; set; }

        public string HeadhunterId { get; set; }

        public string Headhunter { get; set; }

        public int CandidatesCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<JobOffer, JobOfferHeadhunterListItemViewModel>()
                   .ForMember(m => m.Organization, opts => opts.MapFrom(j => j.Organization.Name))
                   .ForMember(m => m.HeadhunterId, opts => opts.MapFrom(j => j.HeadhunterProfileId))
                   .ForMember(m => m.CandidatesCount, opts => opts.MapFrom(j => j.Candidacies.Count))
                   .ForMember(m => m.Headhunter, opts => opts.MapFrom(j => j.Headhunter.User.UserName))
                   .ForMember(m => m.OrganizationId, opts => opts.MapFrom(j => j.Organization.Id));
        }
    }
}
