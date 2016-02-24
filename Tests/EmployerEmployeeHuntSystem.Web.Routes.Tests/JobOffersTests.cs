namespace EmployerEmployeeHuntSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class JobOffersTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void DetailsShouldMapCorrectlyWithValidId()
        {
            int? id = 42;
            string url = string.Format("/JobOffers/Details/{0}", id);
            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.Details(id));
        }

        [Test]
        public void DetailsShouldMapCorrectlyWithNullId()
        {
            int? id = null;
            string url = string.Format("/JobOffers/Details/{0}", id);
            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.Details(id));
        }

        [Test]
        public void DetailsShouldMapCorrectlyWithNoId()
        {
            string url = "/JobOffers/Details";
            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.Details(null));
        }
    }
}
