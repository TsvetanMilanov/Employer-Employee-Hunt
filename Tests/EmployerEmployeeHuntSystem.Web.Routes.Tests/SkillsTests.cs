namespace EmployerEmployeeHuntSystem.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using NUnit.Framework;
    using MvcRouteTester;

    [TestFixture]
    public class SkillsTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void NamesShouldMapCorrectly()
        {
            string filter = "test";

            string url = string.Format("/Skills/Names?filter={0}", filter);

            this.routeCollection.ShouldMap(url).To<SkillsController>(c => c.Names(filter));
        }
    }
}
