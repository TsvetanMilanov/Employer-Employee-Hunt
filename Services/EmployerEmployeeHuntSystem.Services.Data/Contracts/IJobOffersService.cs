namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IJobOffersService
    {
        IQueryable<JobOffer> GetAll();

        IQueryable<JobOffer> GetByOrganizationId(int organizationId);

        JobOffer GetById(int id);

        JobOffer AddJobOffer(
            int organizationId,
            ICollection<int> requiredSkillsIds,
            int minimumCandidatesCount,
            DateTime registrationDate);

        void Delete(int id);
    }
}
