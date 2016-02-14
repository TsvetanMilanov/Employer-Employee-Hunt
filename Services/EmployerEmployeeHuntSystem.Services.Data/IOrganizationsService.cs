namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        Organization GetById(int id);

        Organization Create(string name, string userId, DateTime foundedOn);
    }
}
