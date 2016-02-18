namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using ViewModels.DeveloperProfiles;
    using ViewModels.Home;
    using ViewModels.Organizations;

    public class HomeController : BaseController
    {
        private const string StatisticsCacheKey = "statistics";
        private const string DevelopersCacheKey = "developers";
        private const string OrganizationsCacheKey = "organizations";

        private IStatisticsService statistics;
        private IDeveloperProfilesService developers;
        private IOrganizationsService organizations;

        public HomeController(
            IStatisticsService statistics,
            IDeveloperProfilesService developers,
            IOrganizationsService organizations)
        {
            this.statistics = statistics;
            this.developers = developers;
            this.organizations = organizations;
        }

        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel();

            indexViewModel.Statistics = this.Cache.Get(StatisticsCacheKey, () => this.statistics.GetFullStatistics(), 15 * 60);
            indexViewModel.TopDevelopers = this.Cache.Get(DevelopersCacheKey, () => this.developers.GetTop().To<DeveloperProfileViewModel>().ToList(), 15 * 60);
            indexViewModel.TopOrganizations = this.Cache.Get(OrganizationsCacheKey, () => this.organizations.GetTop().To<OrganizationViewModel>().ToList(), 15 * 60);

            return this.View(indexViewModel);
        }
    }
}
