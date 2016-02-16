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
        private IDbRepository<Candidacy, int> candidacies;
        private IGenericRepository<User> users;

        public JobOffersService(
            IDbRepository<JobOffer, int> jobOffers,
            IDbRepository<Organization, int> organizations,
            IDbRepository<Skill, int> skills,
            IDbRepository<Candidacy, int> candidacies,
            IGenericRepository<User> users)
        {
            this.jobOffers = jobOffers;
            this.organizations = organizations;
            this.skills = skills;
            this.candidacies = candidacies;
            this.users = users;
        }

        public void AddCandidate(string userId, int jobOfferId, string headhunterId)
        {
            var user = this.users.GetById(userId);

            if (user.HeadhunterProfile == null)
            {
                user.HeadhunterProfile = new HeadhunterProfile
                {
                    UserId = user.Id
                };

                this.users.Update(user);
                this.users.SaveChanges();
            }


            var candidacy = new Candidacy
            {
                DeveloperProfileId = userId,
                HeadhunterProfileId = headhunterId,
                JobOfferId = jobOfferId,
                IsApproved = false
            };

            this.candidacies.Add(candidacy);
            this.candidacies.Save();
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

        public void SetActive(int id)
        {
            var jobOffer = this.jobOffers.GetById(id);

            jobOffer.IsActive = true;

            this.jobOffers.Update(jobOffer);

            this.jobOffers.Save();
        }

        public void SetInActive(int id)
        {
            var jobOffer = this.jobOffers.GetById(id);

            jobOffer.IsActive = false;

            this.jobOffers.Update(jobOffer);

            this.jobOffers.Save();
        }
    }
}
