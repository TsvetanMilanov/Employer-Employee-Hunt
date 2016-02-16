namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System.ComponentModel.DataAnnotations;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditOrganizationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        [MinLength(DatabaseConstants.MinOrganizationNameLength)]
        [MaxLength(DatabaseConstants.MaxOrganizationNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
