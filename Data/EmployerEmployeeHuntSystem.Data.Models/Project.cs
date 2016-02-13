namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using Constants;

    public class Project : BaseModel<int>
    {
        [MinLength(DatabaseConstants.MinProjectLinkLength)]
        [MaxLength(DatabaseConstants.MaxProjectLinkLength)]
        [Required]
        public string Link { get; set; }

        [MinLength(DatabaseConstants.MinProjectNameLength)]
        [MaxLength(DatabaseConstants.MaxProjectNameLength)]
        [Required]
        public string Name { get; set; }

        [MinLength(DatabaseConstants.MinProjectDescriptionLength)]
        [MaxLength(DatabaseConstants.MaxProjectDescriptionLength)]
        [Required]
        public string Description { get; set; }
    }
}
