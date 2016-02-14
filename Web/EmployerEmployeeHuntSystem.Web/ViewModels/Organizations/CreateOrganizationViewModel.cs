namespace EmployerEmployeeHuntSystem.Web.ViewModels.Organizations
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class CreateOrganizationViewModel : BaseViewModel
    {
        [MinLength(DatabaseConstants.MinOrganizationNameLength)]
        [MaxLength(DatabaseConstants.MaxOrganizationNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
