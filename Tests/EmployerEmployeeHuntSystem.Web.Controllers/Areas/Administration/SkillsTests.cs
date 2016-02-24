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
    using ViewModels.Skills;
    using Web.Areas.Administration.Controllers;

    public class SkillsTests
    {
        private SkillsController controller;

        [TestFixtureSetUp]
        public void Init()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(SkillsController).Assembly);

            var skills = new Mock<ISkillsService>();
            skills.Setup(x => x.Edit(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new Skill
                {
                    Id = 42
                });

            skills.Setup(x => x.GetAll())
                .Returns(new List<Skill> {
                       new Skill {
                            Id = 42
                        }
                    }.AsQueryable());

            this.controller = new SkillsController(skills.Object);
        }

        [Test]
        public void EditShouldRedirectCorrectly()
        {
            SkillViewModel skill = new SkillViewModel
            {
                Id = 42,
                Name = "C#"
            };

            this.controller.WithCallTo(x => x.Edit(skill))
                    .ShouldRedirectTo(x => x.Index);
        }

        [Test]
        public void IndexShouldReturnCorrectViewModel()
        {
            this.controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<SkillViewModel>>();
        }
    }
}
