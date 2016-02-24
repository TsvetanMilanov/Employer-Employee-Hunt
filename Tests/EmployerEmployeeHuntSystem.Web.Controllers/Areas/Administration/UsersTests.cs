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
    using Web.Areas.Administration.ViewModels.Users;

    public class UsersTests
    {
        private UsersController controller;

        [TestFixtureSetUp]
        public void Init()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(UsersController).Assembly);

            var users = new Mock<IUsersService>();
            users.Setup(x => x.Edit(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            users.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User
                {
                    Id = "userId"
                });

            users.Setup(x => x.GetAll())
                .Returns(new List<User> {
                       new User {
                            Id = "userId"
                        }
                    }.AsQueryable());

            users.Setup(x => x.GetUsersUserNames(It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "username1",
                    "username2"
                }.AsQueryable());

            this.controller = new UsersController(users.Object);
        }

        [Test]
        public void IndexShouldRenderCorrectView()
        {
            this.controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<UserAdministrationViewModel>>()
                .AndNoModelErrors();
        }

        [Test]
        public void NamesShouldReturnJson()
        {
            string filter = "test";

            this.controller.WithCallTo(x => x.Names(filter))
                .ShouldReturnJson();
        }

        [Test]
        public void EditWithGetRequestShouldRenderCorrectView()
        {
            string id = "userId";

            this.controller.WithCallTo(x => x.Edit(id))
                .ShouldRenderDefaultView()
                .WithModel<UserAdministrationViewModel>()
                .AndNoModelErrors();
        }

        [Test]
        public void EditWithPostRequestShouldRedirectCorrectly()
        {
            UserAdministrationViewModel model = new UserAdministrationViewModel
            {
                Email = "some@mail.com",
                Id = "userId",
                PhoneNumber = "123",
                UserName = "username"
            };

            this.controller.WithCallTo(x => x.Edit(model))
                .ShouldRedirectTo(x => x.Index());
        }
    }
}
