namespace EmployerEmployeeHuntSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels.Organizations;

    [TestFixture]
    public class OrganizationsTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void AddShouldMapCorrectly()
        {
            CreateOrganizationViewModel model = new CreateOrganizationViewModel();

            string url = "/Organizations/Create";

            this.routeCollection.ShouldMap(url).To<OrganizationsController>(c => c.Create(model));
        }
    }
}
