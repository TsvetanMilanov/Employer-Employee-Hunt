namespace EmployerEmployeeHuntSystem.Web.ViewModels.JobOffers
{
    using System.Collections.Generic;
    using Organizations;

    public class JobOfferIndexViewModel : BaseViewModel
    {
        public OrganizationViewModel Organization { get; set; }

        public ICollection<JobOfferViewModel> JobOffers { get; set; }
    }
}
