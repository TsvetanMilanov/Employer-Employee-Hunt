namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private IStatisticsService statistics;

        public HomeController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }

        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel();

            indexViewModel.Statistics = this.Cache.Get("statistics", () => this.statistics.GetFullStatistics(), 15 * 60);

            return this.View(indexViewModel);
        }
    }
}
