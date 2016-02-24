namespace EmployerEmployeeHuntSystem.Web.Routes.Tests.Areas.Administration
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Web.Areas.Administration;
    using Web.Areas.Administration.Controllers;

    [TestFixture]
    public class JobOffersTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();

            var areaRegistration = new AdministrationAreaRegistration();
            var context = new AreaRegistrationContext(areaRegistration.AreaName, this.routeCollection);
            areaRegistration.RegisterArea(context);

            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void IndexShouldMapCorrectly()
        {
            string url = "/Administration/JobOffers/Index";

            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.Index());
        }

        [Test]
        public void ClearAssignmentShouldMapCorrectly()
        {
            int id = 42;

            string url = string.Format("/Administration/JobOffers/ClearAssignment/{0}", id);

            this.routeCollection.ShouldMap(url).To<JobOffersController>(c => c.ClearAssignment(id));
        }
    }
}
