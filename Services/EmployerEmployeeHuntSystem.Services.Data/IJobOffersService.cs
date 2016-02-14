namespace EmployerEmployeeHuntSystem.Services.Data
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
            ICollection<string> requiredSkillsNames,
            int minimumCandidatesCount,
            DateTime registrationDate);
    }
}
