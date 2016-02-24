namespace EmployerEmployeeHuntSystem.Web.Controllers
{
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class CandidaciesTests
    {
        private CandidaciesController controller;

        [TestFixtureSetUp]
        public void Init()
        {
            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(CandidaciesController).Assembly);

            var candidacies = new Mock<ICandidaciesService>();
            candidacies.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Data.Models.Candidacy());

            candidacies.Setup(x => x.Approve(It.IsAny<int>()));

            this.controller = new CandidaciesController(candidacies.Object);
        }

        [Test]
        public void ApproveShouldRedirectCorrectly()
        {
            int id = 42;

            this.controller.WithCallTo(x => x.Approve(id))
                    .ShouldRedirectTo<JobOffersController>(x => x.Details(id));
        }

        [Test]
        public void DeleteShouldRedirectCorrectly()
        {
            int id = 42;

            this.controller.WithCallTo(x => x.Delete(id))
                    .ShouldRedirectTo<JobOffersController>(x => x.Details(id));
        }
    }
}
