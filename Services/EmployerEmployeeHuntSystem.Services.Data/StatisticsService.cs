namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class StatisticsService : IStatisticsService
    {
        private IDbRepository<HeadhunterProfile, string> headHunters;
        private IDbRepository<DeveloperProfile, string> developers;
        private IDbRepository<Organization, int> organizations;
        private IDbRepository<JobOffer, int> jobOffers;

        public StatisticsService(
            IDbRepository<HeadhunterProfile, string> headHunters,
            IDbRepository<DeveloperProfile, string> developers,
            IDbRepository<Organization, int> organizations,
            IDbRepository<JobOffer, int> jobOffers)
        {
            this.headHunters = headHunters;
            this.developers = developers;
            this.organizations = organizations;
            this.jobOffers = jobOffers;
        }

        public IDictionary<string, int> GetFullStatistics()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            result.Add("Organizations", this.organizations.All().Count());
            result.Add("Job Offers", this.jobOffers.All().Count());
            result.Add("Developers", this.developers.All().Count());
            result.Add("Headhunters", this.headHunters.All().Count());

            return result;
        }
    }
}
