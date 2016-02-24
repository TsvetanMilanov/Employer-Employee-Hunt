namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;
    using ViewModels.DeveloperProfiles;
    using ViewModels.Skills;

    public class DevelopersTests
    {
        private DevelopersController controller;

        [TestFixtureSetUp]
        public void Init()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(DevelopersController).Assembly);

            var developers = new Mock<IDeveloperProfilesService>();
            developers.Setup(d => d.GetAll())
                .Returns(new List<DeveloperProfile>
                {
                    new DeveloperProfile
                    {
                        Id = "userId"
                    }
                }.AsQueryable());

            this.controller = new DevelopersController(developers.Object);
        }

        [Test]
        public void AllShouldRenderCorrectView()
        {
            this.controller.WithCallTo(x => x.All())
                    .ShouldRenderDefaultView()
                    .WithModel<DeveloperProfileListViewModel>();
        }

        [Test]
        public void AddSkillShouldRenderCorrectView()
        {
            this.controller.WithCallTo(x => x.AddSkill())
                    .ShouldRenderDefaultView()
                    .WithModel<SkillViewModel>();
        }
    }
}
