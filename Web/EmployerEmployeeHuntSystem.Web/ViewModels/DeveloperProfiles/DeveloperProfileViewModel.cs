namespace EmployerEmployeeHuntSystem.Web.ViewModels.DeveloperProfiles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Account;
    using Data.Models;
    using Infrastructure.Mapping;
    using Projects;
    using Skills;

    public class DeveloperProfileViewModel : IMapFrom<DeveloperProfile>
    {
        public string GithubProfile { get; set; }

        public bool? IsAvailableForHire { get; set; }

        [UIHint("ICollectionSkillViewModel")]
        public ICollection<SkillViewModel> Skills { get; set; }

        public ICollection<ProjectViewModel> TopProjects { get; set; }

        public UserViewModel User { get; set; }
    }
}
