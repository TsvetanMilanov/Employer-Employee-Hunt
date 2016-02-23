namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using Candidacies;
    using Organizations;

    public class JobOfferFullDetailsViewModel
    {
        public JobOfferViewModel JobOffer { get; set; }

        public IEnumerable<CandidacyViewModel> Candidacies { get; set; }

        public OrganizationViewModel Organization { get; set; }
    }
}
