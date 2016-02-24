namespace EmployerEmployeeHuntSystem.Web.Controllers.Areas.Administration
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;
    using Web.Areas.Administration.Controllers;
    using Web.Areas.Administration.ViewModels.Organizations;

    public class OrganizationsTests
    {
        private OrganizationsController controller;

        [TestFixtureSetUp]
        public void Init()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(OrganizationsController).Assembly);

            var organizations = new Mock<IOrganizationsService>();
            organizations.Setup(x => x.Edit(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Organization
                {
                    Id = 42
                });

            organizations.Setup(x => x.GetAll())
                .Returns(new List<Organization> {
                       new Organization {
                            Id = 42
                        }
                    }.AsQueryable());

            organizations.Setup(x => x.GetAllWithDeleted())
                .Returns(new List<Organization> {
                       new Organization {
                            Id = 42
                        }
                    }.AsQueryable());

            this.controller = new OrganizationsController(organizations.Object);
        }

        [Test]
        public void IndexShouldReturnCorrectView()
        {
            this.controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<OrganizationAdministrationViewModel>>()
                .AndNoModelErrors();
        }

        [Test]
        public void DeletedShouldReturnCorrectView()
        {
            this.controller.WithCallTo(x => x.Deleted())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<OrganizationAdministrationViewModel>>()
                .AndNoModelErrors();
        }

        [Test]
        public void EditShouldRetirectCorrectly()
        {
            OrganizationAdministrationEditViewModel model = new OrganizationAdministrationEditViewModel
            {
                Id = 42,
                Name = "Test name"
            };

            this.controller.WithCallTo(x => x.Edit(model))
                .ShouldRedirectTo(x => x.Index());
        }
    }
}
