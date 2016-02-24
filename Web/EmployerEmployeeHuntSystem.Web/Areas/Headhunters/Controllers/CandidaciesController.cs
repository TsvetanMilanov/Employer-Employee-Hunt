namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Web.ViewModels.Candidacies;

    public class CandidaciesController : HeadhuntersBaseController
    {
        private ICandidaciesService candidacies;

        public CandidaciesController(ICandidaciesService candidacies)
        {
            this.candidacies = candidacies;
        }

        public ActionResult Approved()
        {
            var model = this.Mapper.Map<IEnumerable<CandidacyViewModel>>(this.candidacies.GetApprovedForUser(this.User.Identity.GetUserId())).ToList();

            return this.View(model);
        }
    }
}
