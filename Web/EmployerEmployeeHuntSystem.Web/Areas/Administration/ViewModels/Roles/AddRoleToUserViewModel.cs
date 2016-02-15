namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Roles
{
    using System.ComponentModel.DataAnnotations;
    using Web.ViewModels;

    public class AddRoleToUserViewModel : BaseViewModel
    {
        [Required]
        public string Role { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
