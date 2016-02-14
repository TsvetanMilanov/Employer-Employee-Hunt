namespace EmployerEmployeeHuntSystem.Web.ViewModels.DeveloperProfiles
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Projects;
    using Skills;

    public class DeveloperProfileViewModel : BaseViewModel, IMapFrom<DeveloperProfile>
    {
        public string GithubProfile { get; set; }

        public bool IsAvailableForHire { get; set; }

        public ICollection<SkillViewModel> Skills { get; set; }

        public ICollection<ProjectViewModel> TopProjects { get; set; }
    }
}
