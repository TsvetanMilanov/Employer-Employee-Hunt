namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class OrganizationsService : IOrganizationsService
    {
        private IDbRepository<Organization, int> organizations;
        private IGenericRepository<User> users;

        public OrganizationsService(IDbRepository<Organization, int> organizations, IGenericRepository<User> users)
        {
            this.organizations = organizations;
            this.users = users;
        }

        public Organization Create(string name, string userId, DateTime foundedOn)
        {
            Organization organization = new Organization();

            organization.Name = name;
            organization.FoundedOn = foundedOn;
            organization.UserId = userId;

            this.organizations.Add(organization);
            this.organizations.Save();

            return organization;
        }

        public void Delete(int id)
        {
            Organization organization = this.organizations.GetById(id);

            this.organizations.Delete(organization);
            this.organizations.Save();
        }

        public Organization Edit(int id, string name)
        {
            Organization organization = this.organizations.GetById(id);

            organization.Name = name;

            this.organizations.Update(organization);

            this.organizations.Save();

            return organization;
        }

        public void Edit(int id, string name, DateTime foundedOn, string founderEmail)
        {
            Organization organization = this.organizations.GetById(id);
            User newFounder = this.users.All().FirstOrDefault(u => u.Email == founderEmail);

            organization.Name = name;
            organization.FoundedOn = foundedOn;
            organization.Founder = newFounder;

            this.organizations.Update(organization);

            this.organizations.Save();
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }

        public IQueryable<Organization> GetAllWithDeleted()
        {
            return this.organizations.AllWithDeleted();
        }

        public IQueryable<Organization> GetByFounderId(string id)
        {
            return this.organizations.All()
                .Where(o => o.UserId == id);
        }

        public Organization GetById(int id)
        {
            return this.organizations.GetById(id);
        }

        public Organization Restore(int id)
        {
            var organization = this.organizations.AllWithDeleted().FirstOrDefault(o => o.Id == id);

            organization.IsDeleted = false;
            organization.DeletedOn = null;

            this.organizations.Update(organization);
            this.organizations.Save();

            return organization;
        }
    }
}
