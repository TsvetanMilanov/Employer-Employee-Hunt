namespace EmployerEmployeeHuntSystem.Web.Routes.Tests.Areas.Administration
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using Web.Areas.Administration;
    using Web.Areas.Administration.Controllers;
    using Web.Areas.Administration.ViewModels.Roles;

    [TestFixture]
    public class RolesTests
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
        public void AddRoleToUserShouldMapCorrectly()
        {
            RoleManagementViewModel model = new RoleManagementViewModel();
            string url = "/Administration/Roles/AddRoleToUser";

            this.routeCollection.ShouldMap(url).To<RolesController>(c => c.AddRoleToUser(model));
        }

        [Test]
        public void RemoveRoleFromUserShouldMapCorrectly()
        {
            RoleManagementViewModel model = new RoleManagementViewModel();
            string url = "/Administration/Roles/RemoveRoleFromUser";

            this.routeCollection.ShouldMap(url).To<RolesController>(c => c.RemoveRoleFromUser(model));
        }

        [Test]
        public void NamesShouldMapCorrectly()
        {
            string filter = "test";

            string url = string.Format("/Administration/Roles/Names?filter={0}", filter);

            this.routeCollection.ShouldMap(url).To<RolesController>(c => c.Names(filter));
        }
    }
}
