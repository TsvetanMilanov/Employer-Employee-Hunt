namespace EmployerEmployeeHuntSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Candidacy : BaseModel<int>
    {
        public int JobOfferId { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public string HeadhunterProfileId { get; set; }

        [ForeignKey("HeadhunterProfileId")]
        public virtual HeadhunterProfile Headhunter { get; set; }

        public string DeveloperProfileId { get; set; }

        [ForeignKey("DeveloperProfileId")]
        public virtual DeveloperProfile Candidate { get; set; }

        public bool IsApproved { get; set; }
    }
}
