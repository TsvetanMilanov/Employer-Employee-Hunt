namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using Web.ViewModels.DeveloperProfiles;

    public class DevelopersController : HeadhuntersBaseController
    {
        private IDeveloperProfilesService developers;

        public DevelopersController(IDeveloperProfilesService developers)
        {
            this.developers = developers;
        }

        public ActionResult CandidatesForJobOffer(int id)
        {
            DeveloperProfileListViewModel model = new DeveloperProfileListViewModel();

            model.DevelopersProfiles = this.developers.GetAll()
                .To<DeveloperProfileViewModel>()
                .ToList();

            return this.View(model);
        }
    }
}
