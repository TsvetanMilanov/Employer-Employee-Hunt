namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IJobOffersService
    {
        IQueryable<JobOffer> GetAll();

        IQueryable<JobOffer> GetActive();

        IQueryable<JobOffer> GetAssigned();

        IQueryable<JobOffer> GetUnassigned();

        IQueryable<JobOffer> GetByOrganizationId(int organizationId);

        IQueryable<JobOffer> GetActiveJoboffersForHeadhunter(string headhunterId);

        JobOffer GetById(int id);

        JobOffer AddJobOffer(
            int organizationId,
            ICollection<int> requiredSkillsIds,
            int minimumCandidatesCount,
            DateTime registrationDate);

        void Delete(int id);

        void SetActive(int id);

        void SetInActive(int id);

        void AddCandidate(string userId, int jobOfferId, string headhunterId);

        void ClearAssignment(int id);
    }
}
