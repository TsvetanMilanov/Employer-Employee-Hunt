namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.JobOffers;

    public class JobOffersController : HeadhuntersBaseController
    {
        private IJobOffersService jobOffers;

        public JobOffersController(IJobOffersService jobOffers)
        {
            this.jobOffers = jobOffers;
        }

        [HttpGet]
        public ActionResult ListAll()
        {
            var allJobOffers = this.jobOffers.GetAll()
                .To<JobOfferHeadhunterListItemViewModel>()
                .ToList();

            var model = new JobOffersListAllViewModel();
            model.JobOffers = allJobOffers;

            return this.View(model);
        }

        public ActionResult Current()
        {
            return this.View();
        }
    }
}
