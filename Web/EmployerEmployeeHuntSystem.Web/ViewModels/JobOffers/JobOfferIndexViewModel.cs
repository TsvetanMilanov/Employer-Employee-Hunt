namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Organizations;

    public class JobOfferIndexViewModel
    {
        public OrganizationViewModel Organization { get; set; }

        [UIHint("IEnumerableJobOffer")]
        public ICollection<JobOfferViewModel> JobOffers { get; set; }
    }
}
