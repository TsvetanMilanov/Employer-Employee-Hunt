namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Constants;

    public class JobOfferAddViewModel
    {
        public int OrganizationId { get; set; }

        [Display(Name = "Required Skills")]
        [Required]
        public ICollection<string> RequiredSkills { get; set; }

        [Display(Name = "Minimum Candidates Count")]
        [Range(DatabaseConstants.MinCanditatesForJobOffer, int.MaxValue)]
        public int MinimumCandidatesCount { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }
    }
}
