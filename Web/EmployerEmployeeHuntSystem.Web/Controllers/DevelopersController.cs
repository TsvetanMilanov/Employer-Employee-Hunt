namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.DeveloperProfiles;
    using ViewModels.Skills;

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

            this.developerProfiles.Create(this.User.Identity.GetUserId(), model.GithubProfile, model.TopProjectsLinks);

            this.SetTempDataSuccessMessage("Developer profile created successfully!");

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var currentUser = this.GetCurrentUser();

            DeveloperProfileEditViewModel model = new DeveloperProfileEditViewModel();

            model.GithubProfile = currentUser.DeveloperProfile.GithubProfile;
            model.TopProjectsLinks = currentUser.DeveloperProfile.TopProjects.Select(p => p.Link).ToList();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(DeveloperProfileEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var currentUser = this.GetCurrentUser();

            this.developerProfiles.Edit(currentUser.Id, model.GithubProfile, model.TopProjectsLinks);

            this.SetTempDataSuccessMessage("Your developer profile was edited successfully!");

            return this.Redirect("Index");
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return this.View(new SkillViewModel());
        }

        [HttpPost]
        public ActionResult AddSkill(SkillViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.developerProfiles.AddSkill(this.GetCurrentUser().Id, model.Name);

            this.SetTempDataSuccessMessage("The skill is added to your developer profile!");

            return this.RedirectToAction("Index");
        }
    }
}
