namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IRolesService
    {
        IQueryable<string> GetRolesNamesByFilter(string filter);

        void AddRoleToUser(string userName, string roleName);

        void RemoveRoleFromUser(string userName, string roleName);

        void Add(string name);

        void Remove(string name);

        IQueryable<IdentityRole> GetAll();
    }
}
