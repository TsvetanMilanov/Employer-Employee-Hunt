namespace EmployerEmployeeHuntSystem.Web.ViewModels.Projects
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProjectViewModel : BaseViewModel, IMapFrom<Project>
    {
        public string Link { get; set; }

        public string Name { get; set; }
    }
}
