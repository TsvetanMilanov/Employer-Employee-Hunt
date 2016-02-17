namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.ActionAttributes;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.Candidacies;
    using ViewModels.JobOffers;
    using ViewModels.Organizations;

    [Authorize]
    public class JobOffersController : BaseController
    {
        // Key to pass to the OrganizationFounder attribute to check if the current user is the founder of the organization.
        private const string OrganizationIdRequestKey = "organizationId";

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

        [OrganizationFounder(OrganizationIdKey = OrganizationIdRequestKey)]
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

            JobOffer jobOffer = this.jobOffers.GetById(id.Value);

            JobOfferViewModel jobOfferViewModel = this.Mapper.Map<JobOfferViewModel>(jobOffer);

            JobOfferFullDetailsViewModel model = new JobOfferFullDetailsViewModel
            {
                JobOffer = jobOfferViewModel,
                Candidacies = this.Mapper.Map<IEnumerable<CandidacyViewModel>>(jobOffer.Candidacies.Where(j => j.IsDeleted == false))
            };

            if (jobOffer == null)
            {
                return this.HttpNotFound();
            }

            return this.View(model);
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

        public ActionResult SetInActive(int id)
        {
            this.jobOffers.SetInActive(id);

            this.SetTempDataSuccessMessage("The job offer was set as inactive!");

            return this.RedirectToAction("Details", "Organizations", new { id = this.jobOffers.GetById(id).OrganizationId });
        }

        public ActionResult SetActive(int id)
        {
            this.jobOffers.SetActive(id);

            this.SetTempDataSuccessMessage("The job offer was set as active!");

            return this.RedirectToAction("Details", "Organizations", new { id = this.jobOffers.GetById(id).OrganizationId });
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
