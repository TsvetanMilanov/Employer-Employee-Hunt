namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IUsersService
    {
        IEnumerable<User> GetAll();

        User GetById(string id);

        IQueryable<string> GetUsersUserNames(string filter);
    }
}
