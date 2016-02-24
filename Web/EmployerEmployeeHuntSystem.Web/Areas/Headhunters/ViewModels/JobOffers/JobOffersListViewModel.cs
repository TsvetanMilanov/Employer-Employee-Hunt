namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Web.ViewModels.JobOffers;

    public class JobOffersListViewModel
    {
        [UIHint("IEnumerableJobOffer")]
        public ICollection<JobOfferViewModel> JobOffers { get; set; }
    }
}
