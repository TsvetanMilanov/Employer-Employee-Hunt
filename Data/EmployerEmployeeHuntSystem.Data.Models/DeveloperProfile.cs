namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Constants;

    public class DeveloperProfile : BaseModel<string>
    {
        public DeveloperProfile()
        {
            this.Skills = new HashSet<Skill>();
            this.TopProjects = new HashSet<Project>();
        }

        [Key]
        [ForeignKey("User")]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public virtual User User { get; set; }

        public bool? IsAvailableForHire { get; set; }

        [RegularExpression(DatabaseConstants.GithubLinkRegex)]
        [Required]
        public string GithubProfile { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Project> TopProjects { get; set; }
    }
}
