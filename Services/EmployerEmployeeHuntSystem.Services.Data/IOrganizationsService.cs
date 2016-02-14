namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        Organization Create(string name, string userId, DateTime foundedOn);
    }
}
