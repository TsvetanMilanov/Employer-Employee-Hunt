namespace EmployerEmployeeHuntSystem.Web.Routes.Tests
{
    using System;
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels.DeveloperProfiles;
    using ViewModels.Skills;

    [TestFixture]
    public class DevelopersTests
    {
        private RouteCollection routeCollection;

        [SetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void DetailsShouldMapCorrectly()
        {
            string id = Guid.NewGuid().ToString();

            string url = string.Format("/Developers/Details/{0}", id);

            this.routeCollection.ShouldMap(url).To<DevelopersController>(c => c.Details(id));
        }

        [Test]
        public void CreateProfileShouldMapCorrectly()
        {
            DeveloperProfileCreateViewModel model = new DeveloperProfileCreateViewModel();

            string url = "/Developers/CreateProfile";

            this.routeCollection.ShouldMap(url).To<DevelopersController>(c => c.CreateProfile(model));
        }
    }
}
