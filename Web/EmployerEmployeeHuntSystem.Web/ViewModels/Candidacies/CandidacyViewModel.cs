namespace EmployerEmployeeHuntSystem.Web.ViewModels.Candidacies
{
    using System;
    using AutoMapper;
    using Data.Models;
    using DeveloperProfiles;
    using Infrastructure.Mapping;
    using JobOffers;

    public class CandidacyViewModel : IMapFrom<Candidacy>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HeadhunterProfileId { get; set; }

        public DeveloperProfileViewModel Candidate { get; set; }

        public JobOfferViewModel JobOffer { get; set; }

        public bool IsApproved { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Candidacy, CandidacyViewModel>()
                .ForMember(m => m.Candidate, opts => opts.MapFrom(c => c.Candidate));
        }
    }
}
