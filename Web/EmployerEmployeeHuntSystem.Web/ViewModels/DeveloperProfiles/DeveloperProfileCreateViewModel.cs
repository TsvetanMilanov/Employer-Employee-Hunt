namespace EmployerEmployeeHuntSystem.Web.ViewModels.DeveloperProfiles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class DeveloperProfileCreateViewModel
    {
        [Display(Name = "Github Profile")]
        [RegularExpression(DatabaseConstants.GithubLinkRegex, ErrorMessage = "The Github Profile field must be valid link to Github profile.")]
        [Required]
        public string GithubProfile { get; set; }

        [Display(Name = "Top Projects Links")]
        public ICollection<string> TopProjectsLinks { get; set; }
    }
}
