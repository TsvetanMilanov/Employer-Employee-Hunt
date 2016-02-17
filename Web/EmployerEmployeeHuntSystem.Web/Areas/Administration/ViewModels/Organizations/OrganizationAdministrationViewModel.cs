namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Organizations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationAdministrationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        [MinLength(DatabaseConstants.MinOrganizationNameLength)]
        [MaxLength(DatabaseConstants.MaxOrganizationNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
