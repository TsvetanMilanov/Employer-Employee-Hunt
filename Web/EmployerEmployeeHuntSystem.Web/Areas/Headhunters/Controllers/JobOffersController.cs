﻿namespace EmployerEmployeeHuntSystem.Web.Areas.Headhunters.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.JobOffers;
    using Web.ViewModels.JobOffers;

    public class JobOffersController : HeadhuntersBaseController
    {
        private IJobOffersService jobOffers;

        public JobOffersController(IJobOffersService jobOffers)
        {
            this.jobOffers = jobOffers;
        }

        [HttpGet]
        public ActionResult ListAll()
        {
            var allJobOffers = this.jobOffers.GetAll()
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = allJobOffers;

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Active()
        {
            var activeJobOffers = this.jobOffers.GetActive()
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = activeJobOffers;

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Unassigned()
        {
            var unassignedJobOffers = this.jobOffers.GetUnassigned()
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = unassignedJobOffers;

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Current()
        {
            var result = this.jobOffers.GetActiveJoboffersForHeadhunter(this.User.Identity.GetUserId())
                .To<JobOfferViewModel>()
                .ToList();

            var model = new JobOffersListViewModel();
            model.JobOffers = result;

            return this.View(model);
        }

        public ActionResult SetActive(int id)
        {
            this.jobOffers.SetActive(id);

            this.SetTempDataSuccessMessage("The job offer was set as active!");

            return this.RedirectToAction("ListAll");
        }

        public ActionResult SetInActive(int id)
        {
            this.jobOffers.SetInActive(id);

            this.SetTempDataSuccessMessage("The job offer was set as inactive!");

            return this.RedirectToAction("ListAll");
        }

        public ActionResult AddCandidate(string userId, int jobOfferId)
        {
            this.jobOffers.AddCandidate(userId, jobOfferId, this.User.Identity.GetUserId());

            this.SetTempDataSuccessMessage("Candidate added to job offer.");

            return this.RedirectToAction("CandidatesForJobOffer", "Developers", new { id = jobOfferId });
        }
    }
}
