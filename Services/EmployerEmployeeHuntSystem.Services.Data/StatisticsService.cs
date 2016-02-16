namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class StatisticsService : IStatisticsService
    {
        private IDbRepository<HeadhunterProfile, string> headHunters;
        private IDbRepository<DeveloperProfile, string> developers;
        private IDbRepository<Organization, int> organizations;
        private IDbRepository<JobOffer, int> jobOffers;
        private IGenericRepository<User> users;
        private IGenericRepository<IdentityRole> roles;

        public StatisticsService(
            IDbRepository<HeadhunterProfile, string> headHunters,
            IDbRepository<DeveloperProfile, string> developers,
            IDbRepository<Organization, int> organizations,
            IDbRepository<JobOffer, int> jobOffers,
            IGenericRepository<User> users,
            IGenericRepository<IdentityRole> roles)
        {
            this.headHunters = headHunters;
            this.developers = developers;
            this.organizations = organizations;
            this.jobOffers = jobOffers;
            this.users = users;
            this.roles = roles;
        }

        public IDictionary<string, int> GetFullStatistics()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            result.Add("Organizations", this.organizations.All().Count());
            result.Add("Job Offers", this.jobOffers.All().Count());
            result.Add("Developers", this.developers.All().Count());

            var headhunterRoleId = this.roles.All().FirstOrDefault(r => r.Name == GlobalConstants.HeadhunterRoleName).Id;
            result.Add("Headhunters", this.users.All().Count(u => u.Roles.Any(r => r.RoleId == headhunterRoleId)));

            return result;
        }
    }
}
