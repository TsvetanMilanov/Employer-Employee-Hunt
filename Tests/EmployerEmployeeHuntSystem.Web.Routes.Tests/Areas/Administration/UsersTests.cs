namespace EmployerEmployeeHuntSystem.Web.Routes.Tests.Areas.Administration
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Web.Areas.Administration;
    using Web.Areas.Administration.Controllers;
    using Web.Areas.Administration.ViewModels.Roles;

    public class UsersTests
    {
        private RouteCollection routeCollection;

        [SetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();

            var areaRegistration = new AdministrationAreaRegistration();
            var context = new AreaRegistrationContext(areaRegistration.AreaName, this.routeCollection);
            areaRegistration.RegisterArea(context);

            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void NamesShouldMapCorrectly()
        {
            string filter = "test";

            string url = string.Format("/Administration/Users/Names?filter={0}", filter);

            this.routeCollection.ShouldMap(url).To<UsersController>(c => c.Names(filter));
        }
    }
}
