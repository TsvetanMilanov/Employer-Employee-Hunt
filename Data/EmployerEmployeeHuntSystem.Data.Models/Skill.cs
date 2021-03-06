﻿namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using Constants;

    public class Skill : BaseModel<int>
    {
        public Skill()
        {
            this.Developers = new HashSet<DeveloperProfile>();
            this.JobOffers = new HashSet<JobOffer>();
        }

        [MinLength(DatabaseConstants.MinSkillNameLength)]
        [MaxLength(DatabaseConstants.MaxSkillNameLength)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<DeveloperProfile> Developers { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
