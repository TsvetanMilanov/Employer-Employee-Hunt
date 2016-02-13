namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class HeadhunterProfile : BaseModel<string>
    {
        public HeadhunterProfile()
        {
            this.ApprovedCandidacies = new HashSet<Candidacy>();
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

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Candidacy> ApprovedCandidacies { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}