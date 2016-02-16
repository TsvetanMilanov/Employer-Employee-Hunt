namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Developers;
    using Web.ViewModels.DeveloperProfiles;
    using Web.ViewModels.JobOffers;

    public class DevelopersController : HeadhuntersBaseController
    {
        private IDeveloperProfilesService developers;
        private IJobOffersService jobOffers;

        public DevelopersController(IDeveloperProfilesService developers, IJobOffersService jobOffers)
        {
            this.developers = developers;
            this.jobOffers = jobOffers;
        }

        public ActionResult CandidatesForJobOffer(int id)
        {
            DeveloperProfileListViewModel innerModel = new DeveloperProfileListViewModel();

            innerModel.DevelopersProfiles = this.developers.GetCandidatesForJobOffer(id)
                .To<DeveloperProfileViewModel>()
                .ToList();

            CandidatesForJobOfferViewModel model = new CandidatesForJobOfferViewModel();
            model.ListOfDeveloperProfiles = innerModel;
            model.JobOffer = this.Mapper.Map<JobOfferViewModel>(this.jobOffers.GetById(id));

            return this.View(model);
        }
    }
}
