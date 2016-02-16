namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.ViewModels.JobOffers
{
    using System.Collections.Generic;

    public class JobOffersListAllViewModel
    {
        public ICollection<JobOfferHeadhunterListItemViewModel> JobOffers { get; set; }
    }
}
