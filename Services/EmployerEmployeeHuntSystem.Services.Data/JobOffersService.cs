namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class JobOffersService : IJobOffersService
    {
        private IDbRepository<JobOffer, int> jobOffers;
        private IDbRepository<Organization, int> organizations;
        private IDbRepository<Skill, int> skills;

        public JobOffersService(
            IDbRepository<JobOffer, int> jobOffers,
            IDbRepository<Organization, int> organizations,
            IDbRepository<Skill, int> skills)
        {
            this.jobOffers = jobOffers;
            this.organizations = organizations;
            this.skills = skills;
        }

        public JobOffer AddJobOffer(
            int organizationId,
            ICollection<int> requiredSkillsIds,
            int minimumCandidatesCount,
            DateTime registrationDate)
        {
            JobOffer jobOffer = new JobOffer();

            jobOffer.IsActive = true;
            jobOffer.MinimumCandidatesCount = minimumCandidatesCount;
            jobOffer.OrganizationId = organizationId;
            jobOffer.RegistrationDate = registrationDate;
            jobOffer.RequiredSkills = this.skills.All().Where(s => requiredSkillsIds.Contains(s.Id)).ToList();

            this.jobOffers.Add(jobOffer);
            this.jobOffers.Save();

            return jobOffer;
        }

        public void Delete(int id)
        {
            JobOffer jobOffer = this.jobOffers.GetById(id);

            this.jobOffers.Delete(jobOffer);
            this.jobOffers.Save();
        }

        public IQueryable<JobOffer> GetAll()
        {
            return this.jobOffers.All();
        }

        public JobOffer GetById(int id)
        {
            return this.jobOffers.GetById(id);
        }

        public IQueryable<JobOffer> GetByOrganizationId(int organizationId)
        {
            return this.jobOffers.All()
                .Where(j => j.OrganizationId == organizationId);
        }
    }
}
