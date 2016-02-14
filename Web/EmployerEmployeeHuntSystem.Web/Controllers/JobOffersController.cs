namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.JobOffers;
    using ViewModels.Organizations;

    public class JobOffersController : BaseController
    {
        private IJobOffersService jobOffers;
        private IOrganizationsService organizations;

        public JobOffersController(IJobOffersService jobOffers, IOrganizationsService organizations)
        {
            this.jobOffers = jobOffers;
            this.organizations = organizations;
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

        // GET: JobOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public ActionResult Create()
        {
            ViewBag.HeadhunterProfileId = new SelectList(db.HeadhunterProfiles, "Id", "UserId");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "UserId");
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,HeadhunterProfileId,IsActive,RegistrationDate,MinimumCandidatesCount,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                db.JobOffers.Add(jobOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeadhunterProfileId = new SelectList(db.HeadhunterProfiles, "Id", "UserId", jobOffer.HeadhunterProfileId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "UserId", jobOffer.OrganizationId);
            return View(jobOffer);
        }

        // GET: JobOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeadhunterProfileId = new SelectList(db.HeadhunterProfiles, "Id", "UserId", jobOffer.HeadhunterProfileId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "UserId", jobOffer.OrganizationId);
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,HeadhunterProfileId,IsActive,RegistrationDate,MinimumCandidatesCount,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeadhunterProfileId = new SelectList(db.HeadhunterProfiles, "Id", "UserId", jobOffer.HeadhunterProfileId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "UserId", jobOffer.OrganizationId);
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = db.JobOffers.Find(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobOffer jobOffer = db.JobOffers.Find(id);
            db.JobOffers.Remove(jobOffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
