namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data;
    using ViewModels;
    using ViewModels.DeveloperProfiles;

    [Authorize]
    public class DevelopersController : BaseController
    {
        private IDeveloperProfilesService developerProfiles;

        public DevelopersController(IDeveloperProfilesService developerProfiles)
        {
            this.developerProfiles = developerProfiles;
        }

        public ActionResult Index()
        {
            User currentUser = this.GetCurrentUser();

            if (currentUser.DeveloperProfile == null)
            {
                return this.RedirectToAction("CreateProfile");
            }

            DeveloperProfileViewModel model = this.Mapper.Map<DeveloperProfileViewModel>(currentUser.DeveloperProfile);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            User currentUser = this.GetCurrentUser();

            return this.View(new DeveloperProfileCreateViewModel());
        }

        [HttpPost]
        public ActionResult CreateProfile(DeveloperProfileCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.developerProfiles.Create(model.CurrentUser.Id, model.GithubProfile, model.TopProjectsLinks);

            this.SetTempDataSuccessMessage("Developer profile created successfully!");

            return this.RedirectToAction("Index");
        }
    }
}
