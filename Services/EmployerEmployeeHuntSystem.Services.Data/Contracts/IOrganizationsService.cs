namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        IQueryable<Organization> GetAllWithDeleted();

        IQueryable<Organization> GetByFounderId(string id);

        Organization GetById(int id);

        Organization Create(string name, string userId, DateTime foundedOn);

        Organization Edit(int id, string name);

        Organization Restore(int id);

        void Delete(int id);

        void Edit(int id, string name, DateTime foundedOn, string founderEmail);
    }
}
