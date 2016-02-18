namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IDeveloperProfilesService
    {
        IQueryable<DeveloperProfile> GetAll();

        IQueryable<DeveloperProfile> GetTop(int count = GlobalConstants.DefaultTopEntriesCount);

        IQueryable<DeveloperProfile> GetCandidatesForJobOffer(int jobOfferId);

        DeveloperProfile GetById(string id);

        DeveloperProfile Create(string userId, string githubProfile, ICollection<string> topProjects);

        DeveloperProfile Edit(string userId, string githubProfile, ICollection<string> topProjects, bool isAvailableForHire);

        void AddSkill(string userId, string name);
    }
}
