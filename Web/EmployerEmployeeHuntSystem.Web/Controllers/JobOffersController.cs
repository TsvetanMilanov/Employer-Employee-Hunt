namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.JobOffers;
    using ViewModels.Organizations;

    [Authorize]
    public class JobOffersController : BaseController
    {
        private IJobOffersService jobOffers;
        private IOrganizationsService organizations;
        private ISkillsService skills;

        public JobOffersController(
            IJobOffersService jobOffers,
            IOrganizationsService organizations,
            ISkillsService skills)
        {
            this.jobOffers = jobOffers;
            this.organizations = organizations;
            this.skills = skills;
        }

        public ActionResult Index(int organizationId)
        {
            var jobOffersForOrganization = this.jobOffers.GetByOrganizationId(organizationId)
                .To<JobOfferViewModel>()
                .ToList();

            JobOfferIndexViewModel model = new JobOfferIndexViewModel();
            model.Organization = this.Mapper.Map<OrganizationViewModel>(this.organizations.GetById(organizationId));
            model.JobOffers = jobOffersForOrganization;

            return this.View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            JobOfferViewModel jobOffer = this.Mapper.Map<JobOfferViewModel>(this.jobOffers.GetById(id.Value));
            if (jobOffer == null)
            {
                return this.HttpNotFound();
            }

            return this.View(jobOffer);
        }

        public ActionResult Add(int organizationId)
        {
            JobOfferAddViewModel model = this.CreateJobOfferAddViewModel(organizationId);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(JobOfferAddViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.jobOffers.AddJobOffer(model.OrganizationId, model.RequiredSkills.Select(int.Parse).ToList(), model.MinimumCandidatesCount, DateTime.Now);

                this.SetTempDataSuccessMessage("The job offer is added successfully!");

                return this.RedirectToAction("Index", new { organizationId = model.OrganizationId });
            }

            JobOfferAddViewModel blankModel = this.CreateJobOfferAddViewModel(model.OrganizationId);
            model.Skills = blankModel.Skills;

            return this.View(model);
        }

        public ActionResult Delete(int id)
        {
            int organizationId = this.jobOffers.GetById(id).OrganizationId;

            this.jobOffers.Delete(id);

            this.SetTempDataSuccessMessage("Job Offer deleted successfully!");

            return this.RedirectToAction("Index", new { organizationId = organizationId });
        }

        private JobOfferAddViewModel CreateJobOfferAddViewModel(int organizationId)
        {
            JobOfferAddViewModel model = new JobOfferAddViewModel();

            model.OrganizationId = organizationId;
            model.Skills = this.skills.GetAll().Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });

            return model;
        }
    }
}
