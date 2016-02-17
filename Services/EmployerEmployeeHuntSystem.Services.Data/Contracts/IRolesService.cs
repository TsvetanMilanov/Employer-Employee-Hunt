namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;

    public interface IRolesService
    {
        IQueryable<string> GetRolesNamesByFilter(string filter);

        void AddRoleToUser(string userName, string roleName);

        void RemoveRoleFromUser(string userName, string roleName);
    }
}
