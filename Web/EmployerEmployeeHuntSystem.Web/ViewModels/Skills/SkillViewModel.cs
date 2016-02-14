namespace EmployerEmployeeHuntSystem.Web.ViewModels.Skills
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class SkillViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinSkillNameLength)]
        [MaxLength(DatabaseConstants.MaxSkillNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
