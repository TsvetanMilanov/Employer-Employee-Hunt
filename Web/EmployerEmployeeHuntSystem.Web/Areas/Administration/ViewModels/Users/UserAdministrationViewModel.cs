namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Roles;

    public class UserAdministrationViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public virtual string PhoneNumber { get; set; }
    }
}
