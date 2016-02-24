namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.DeveloperProfiles;
    using ViewModels.Skills;

    [Authorize]
    public class DevelopersController : BaseController
    {
        private IDeveloperProfilesService developers;

        public DevelopersController(IDeveloperProfilesService developerProfiles)
        {
            this.developers = developerProfiles;
        }

        public ActionResult Index()
        {
            DeveloperProfile developerProfile = this.developers.GetById(this.User.Identity.GetUserId());

            if (developerProfile == null)
            {
                return this.RedirectToAction("CreateProfile");
            }

            DeveloperProfileViewModel model = this.Mapper.Map<DeveloperProfileViewModel>(developerProfile);

            return this.View(model);
        }

        [AllowAnonymous]
        public ActionResult All()
        {
            DeveloperProfileListViewModel model = new DeveloperProfileListViewModel();

            model.DevelopersProfiles = this.developers.GetAll()
                .To<DeveloperProfileViewModel>()
                .ToList();

            return this.View(model);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            User currentUser = this.GetCurrentUser();

            return this.View(new DeveloperProfileCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile(DeveloperProfileCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.developers.Create(this.User.Identity.GetUserId(), model.GithubProfile, model.TopProjectsLinks);

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
            model.IsAvailableForHire = currentUser.DeveloperProfile.IsAvailableForHire.Value;

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.Redirect("/");
            }

            var developer = this.developers.GetById(id);

            DeveloperProfileViewModel model = this.Mapper.Map<DeveloperProfileViewModel>(developer);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeveloperProfileEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var currentUser = this.GetCurrentUser();

            this.developers.Edit(currentUser.Id, model.GithubProfile, model.TopProjectsLinks, model.IsAvailableForHire);

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

            this.developers.AddSkill(this.GetCurrentUser().Id, model.Name);

            this.SetTempDataSuccessMessage("The skill is added to your developer profile!");

            return this.RedirectToAction("Index");
        }
    }
}
