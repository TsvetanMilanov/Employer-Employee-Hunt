﻿namespace EmployerEmployeeHuntSystem.Web.Areas.Administration.ViewModels.Organizations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Constants;
    using Data.Models;
    using Infrastructure.Mapping;
    using Web.ViewModels.Account;

    public class OrganizationAdministrationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserViewModel Founder { get; set; }

        public DateTime FoundedOn { get; set; }

        [MinLength(DatabaseConstants.MinOrganizationNameLength)]
        [MaxLength(DatabaseConstants.MaxOrganizationNameLength)]
        [Required]
        public string Name { get; set; }
    }
}
