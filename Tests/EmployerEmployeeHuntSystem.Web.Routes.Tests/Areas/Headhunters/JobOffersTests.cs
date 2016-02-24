namespace EmployerEmployeeHuntSystem.Web.Routes.Tests.Areas.Headhunters
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Web.Areas.Headhunters;
    using Web.Areas.Headhunters.Controllers;

    public class JobOffersTests
    {
        private RouteCollection routeCollection;

        [SetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();

            var areaRegistration = new HeadhuntersAreaRegistration();
            var context = new AreaRegistrationContext(areaRegistration.AreaName, this.routeCollection);
            areaRegistration.RegisterArea(context);

            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void AddCandidateShouldMapCorrectly()
        {
            string userId = "userId";
            int jobOfferId = 42;

            string url = string.Format("/Headhunters/JobOffers/AddCandidate?userId={0}&jobOfferId={1}", userId, jobOfferId);

            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.AddCandidate(userId, jobOfferId));
        }
    }
}
