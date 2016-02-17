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
        [Display(Name = "Github Profile")]
        public string GithubProfile { get; set; }

        [Display(Name = "Is Available For Hire")]
        public bool? IsAvailableForHire { get; set; }

        [UIHint("ICollectionSkillViewModel")]
        public ICollection<SkillViewModel> Skills { get; set; }

        [Display(Name = "Top Projects")]
        public ICollection<ProjectViewModel> TopProjects { get; set; }

        public UserViewModel User { get; set; }
    }
}
