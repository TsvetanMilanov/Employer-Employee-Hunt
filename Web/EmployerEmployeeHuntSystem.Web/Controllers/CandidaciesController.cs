namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data.Contracts;

    [Authorize]
    public class CandidaciesController : BaseController
    {
        private ICandidaciesService candidacies;

        public CandidaciesController(ICandidaciesService candidacies)
        {
            this.candidacies = candidacies;
        }

        public ActionResult Approve(int id)
        {
            this.candidacies.Approve(id);

            var jobOfferId = this.candidacies.GetById(id).JobOfferId;

            this.SetTempDataSuccessMessage("The candidacy was approved!");

            return this.RedirectToAction("Details", "JobOffers", new { id = jobOfferId });
        }

        public ActionResult Delete(int id)
        {
            var all = this.candidacies.GetAll().ToList();
            var c = this.candidacies.GetById(id);

            var jobOfferId = this.candidacies.GetById(id).JobOfferId;

            this.candidacies.Delete(id);

            this.SetTempDataSuccessMessage("The candidacy was deleted!");

            return this.RedirectToAction("Details", "JobOffers", new { id = jobOfferId });
        }
    }
}
