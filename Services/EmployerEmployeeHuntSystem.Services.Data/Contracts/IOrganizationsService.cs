namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        Organization GetById(int id);

        Organization Create(string name, string userId, DateTime foundedOn);

        Organization Edit(int id, string name);

        void Delete(int id);

        void Edit(int id, string name, DateTime foundedOn, string founderEmail);
    }
}
