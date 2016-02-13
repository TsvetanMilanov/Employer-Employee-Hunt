namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Constants;

    public class JobOffer : BaseModel<int>
    {
        public JobOffer()
        {
            this.RequiredSkills = new HashSet<Skill>();
            this.Candidacies = new HashSet<Candidacy>();
        }

        public int OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<Skill> RequiredSkills { get; set; }

        public virtual ICollection<Candidacy> Candidacies { get; set; }

        public string HeadhunterProfileId { get; set; }

        [ForeignKey("HeadhunterProfileId")]
        public virtual HeadhunterProfile Headhunter { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Range(DatabaseConstants.MinCanditatesForJobOffer, int.MaxValue)]
        public int MinimumCandidatesCount { get; set; }
    }
}
