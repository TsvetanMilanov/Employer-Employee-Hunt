namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Roles
{
    using System.ComponentModel.DataAnnotations;

    public class AddRoleToUserViewModel
    {
        [Required]
        public string Role { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
