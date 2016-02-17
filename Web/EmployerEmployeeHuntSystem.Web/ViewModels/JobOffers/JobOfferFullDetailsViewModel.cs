namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using Candidacies;

    public class JobOfferFullDetailsViewModel
    {
        public JobOfferViewModel JobOffer { get; set; }

        public IEnumerable<CandidacyViewModel> Candidacies { get; set; }
    }
}
