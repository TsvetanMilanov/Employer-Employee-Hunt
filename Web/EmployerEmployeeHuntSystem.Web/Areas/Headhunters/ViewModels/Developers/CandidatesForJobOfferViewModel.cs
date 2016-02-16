namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.ViewModels.Developers
{
    using Web.ViewModels.DeveloperProfiles;
    using Web.ViewModels.JobOffers;

    public class CandidatesForJobOfferViewModel
    {
        public DeveloperProfileListViewModel ListOfDeveloperProfiles { get; set; }

        public JobOfferViewModel JobOffer { get; set; }
    }
}
