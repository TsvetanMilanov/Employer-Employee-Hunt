namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Headhunters.ViewModels.JobOffers;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using Web.ViewModels.JobOffers;

    public class JobOffersController : AdministrationBaseController
    {
        private IJobOffersService jobOffers;

        public JobOffersController(IJobOffersService jobOffers)
        {
            this.jobOffers = jobOffers;
        }

        public ActionResult Index()
        {
            var allJobOffers = this.jobOffers.GetAll()
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = allJobOffers;

            return this.View(model);
        }

        public ActionResult Assigned()
        {
            var assignedJobOffers = this.jobOffers.GetAssigned()
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = assignedJobOffers;

            return this.View(model);
        }

        public ActionResult ClearAssignment(int id)
        {
            this.jobOffers.ClearAssignment(id);

            this.SetTempDataSuccessMessage("The headhunter was removed from the job offer.");

            return this.RedirectToAction("Index");
        }
    }
}
