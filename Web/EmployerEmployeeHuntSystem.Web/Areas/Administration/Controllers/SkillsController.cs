namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;
    using Web.ViewModels.Skills;

    public class SkillsController : AdministrationBaseController
    {
        private ISkillsService skills;

        public SkillsController(ISkillsService skills)
        {
            this.skills = skills;
        }

        public ActionResult Index()
        {
            var model = this.Mapper.Map<IEnumerable<SkillViewModel>>(this.skills.GetAll().ToList());

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SkillViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.SetTempDataErrorMessage("The name of the skill is required.");
                return this.RedirectToAction("Index");
            }

            this.skills.Add(model.Name);

            this.SetTempDataSuccessMessage("The skill is added!");

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.skills.Delete(id);

            this.SetTempDataSuccessMessage("The skill was deleted!");

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SkillViewModel model = this.Mapper.Map<SkillViewModel>(this.skills.GetById(id));

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SkillViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.SetTempDataErrorMessage("Invalid skill name!");
                return this.View(model);
            }

            this.skills.Edit(model.Id, model.Name);

            this.SetTempDataSuccessMessage("The skill was edited!");

            return this.RedirectToAction("Index");
        }
    }
}
