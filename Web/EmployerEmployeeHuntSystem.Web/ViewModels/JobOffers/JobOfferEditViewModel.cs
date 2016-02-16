namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class JobOfferEditViewModel : IMapFrom<JobOffer>
    {
        public bool IsActive { get; set; }

        public int MinimumCanditatesCount { get; set; }

        public ICollection<string> RequiredSkills { get; set; }
    }
}
