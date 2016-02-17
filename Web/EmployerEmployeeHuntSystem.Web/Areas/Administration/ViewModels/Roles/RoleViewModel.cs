namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Roles
{
    using System.ComponentModel.DataAnnotations;

    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
