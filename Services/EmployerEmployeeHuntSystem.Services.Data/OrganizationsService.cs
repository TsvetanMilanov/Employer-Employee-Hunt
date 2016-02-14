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

        public IQueryable<Organization> GetAll()
        {
            return this.organizations.All();
        }
    }
}
