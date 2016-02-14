namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Constants;

    public class JobOfferAddViewModel : BaseViewModel
    {
        public int OrganizationId { get; set; }

        public ICollection<string> RequiredSkills { get; set; }

        [Range(DatabaseConstants.MinCanditatesForJobOffer, int.MaxValue)]
        public int MinimumCandidatesCount { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Skills { get; set; }
    }
}
