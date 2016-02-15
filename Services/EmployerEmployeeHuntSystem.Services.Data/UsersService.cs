namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class UsersService : IUsersService
    {
        private IGenericRepository<User> users;

        public UsersService(IGenericRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<string> GetUsersUserNames(string filter)
        {
            return this.users.All()
                .Where(u => u.UserName.ToLower().Contains(filter.ToLower()))
                .Select(u => u.UserName);
        }
    }
}
