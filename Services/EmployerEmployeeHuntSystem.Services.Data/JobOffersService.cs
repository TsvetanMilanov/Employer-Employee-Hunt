namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class JobOffersService : IJobOffersService
    {
        private IDbRepository<JobOffer, int> jobOffers;
        private IDbRepository<Organization, int> organizations;

        public JobOffersService(IDbRepository<JobOffer, int> jobOffers, IDbRepository<Organization, int> organizations)
        {
            this.jobOffers = jobOffers;
            this.organizations = organizations;
        }

        public JobOffer AddJobOffer(
            int organizationId,
            ICollection<string> requiredSkillsNames,
            int minimumCandidatesCount,
            DateTime registrationDate)
        {
            JobOffer jobOffer = new JobOffer();

            jobOffer.IsActive = true;
            jobOffer.MinimumCandidatesCount = minimumCandidatesCount;
            jobOffer.OrganizationId = organizationId;
            jobOffer.RegistrationDate = registrationDate;
            jobOffer.RequiredSkills = requiredSkillsNames.Select(s => new Skill { Name = s }).ToList();

            this.jobOffers.Add(jobOffer);
            this.jobOffers.Save();

            return jobOffer;
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
