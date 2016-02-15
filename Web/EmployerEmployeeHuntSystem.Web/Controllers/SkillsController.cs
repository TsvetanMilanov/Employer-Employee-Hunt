namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;

    public class SkillsController : BaseController
    {
        private ISkillsService skills;

        public SkillsController(ISkillsService skills)
        {
            this.skills = skills;
        }

        public ActionResult Names(string filter)
        {
            return this.Json(this.skills.GetAllSkillsNames(filter).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
