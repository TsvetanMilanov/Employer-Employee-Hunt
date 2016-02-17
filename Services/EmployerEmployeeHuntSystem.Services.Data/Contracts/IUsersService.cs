namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(string id);

        User GetByEmail(string email);

        IQueryable<string> GetUsersUserNames(string filter);

        void Edit(string id, string email, string userName, string phoneNumber);

        void Delete(string id);
    }
}
