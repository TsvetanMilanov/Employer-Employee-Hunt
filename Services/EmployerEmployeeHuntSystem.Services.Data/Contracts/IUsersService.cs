namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IUsersService
    {
        User GetById(string id);

        IQueryable<string> GetUsersUserNames(string filter);
    }
}
