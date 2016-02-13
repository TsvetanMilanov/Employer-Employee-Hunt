namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Organization : BaseModel<int>
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }
    }
}
