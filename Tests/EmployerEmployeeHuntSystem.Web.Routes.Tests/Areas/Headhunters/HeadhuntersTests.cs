namespace EmployerEmployeeHuntSystem.Web.Routes.Tests.Areas.Headhunters
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Web.Areas.Headhunters;
    using Web.Areas.Headhunters.Controllers;

    [TestFixture]
    public class HeadhuntersTests
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
        public void IndexShouldMapCorrectly()
        {
            string url = "/Headhunters/Headhunters/Index";

            this.routeCollection.ShouldMap(url).To<HeadhuntersController>(c => c.Index());
        }
    }
}
