namespace EmployerEmployeeHuntSystem.Web.ViewModels.Skills
{
    using System.ComponentModel.DataAnnotations;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class SkillViewModel : BaseViewModel, IMapFrom<Skill>
    {
        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinSkillNameLength)]
        [MaxLength(DatabaseConstants.MaxSkillNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
