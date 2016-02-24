namespace EmployerEmployeeHuntSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class CandidaciesTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void ApproveRouteShouldMapCorrectly()
        {
            int id = 5;
            string route = string.Format("/Candidacies/Approve/{0}", id);

            this.routeCollection.ShouldMap(route).To<CandidaciesController>(c => c.Approve(id));
        }

        [Test]
        public void DeleteRouteShouldMapCorrectly()
        {
            int id = 5;
            string route = string.Format("/Candidacies/Delete/{0}", id);

            this.routeCollection.ShouldMap(route).To<CandidaciesController>(c => c.Delete(id));
        }
    }
}
