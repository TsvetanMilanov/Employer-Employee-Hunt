namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class OrganizationsService : IOrganizationsService
    {
        private IDbRepository<Organization, int> organizations;

        public OrganizationsService(IDbRepository<Organization, int> organizations)
        {
            this.organizations = organizations;
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

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }

        public Organization GetById(int id)
        {
            return this.organizations.GetById(id);
        }
    }
}
