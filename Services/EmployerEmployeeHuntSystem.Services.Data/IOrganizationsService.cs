namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();
    }
}
