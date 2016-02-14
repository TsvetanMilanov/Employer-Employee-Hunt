namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IDeveloperProfilesService
    {
        IQueryable<DeveloperProfile> GetAll();

        DeveloperProfile GetById(string id);

        DeveloperProfile Create(string userId, string githubProfile, ICollection<string> topProjects);
    }
}
