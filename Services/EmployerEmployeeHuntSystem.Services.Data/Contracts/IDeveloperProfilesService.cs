namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IDeveloperProfilesService
    {
        IQueryable<DeveloperProfile> GetAll();

        DeveloperProfile GetById(string id);

        DeveloperProfile Create(string userId, string githubProfile, ICollection<string> topProjects);

        DeveloperProfile Edit(string userId, string githubProfile, ICollection<string> topProjects);

        void AddSkill(string userId, string name);
    }
}
