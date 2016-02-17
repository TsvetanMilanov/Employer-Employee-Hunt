namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
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

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public User GetByEmail(string email)
        {
            return this.users.All().FirstOrDefault(u => u.Email == email);
        }

        public IQueryable<string> GetUsersUserNames(string filter)
        {
            return this.users.All()
                .Where(u => u.UserName.ToLower().Contains(filter.ToLower()))
                .Select(u => u.UserName);
        }

        public void Edit(string id, string email, string userName, string phoneNumber)
        {
            var user = this.users.GetById(id);

            user.Email = email;
            user.UserName = userName;
            user.PhoneNumber = phoneNumber;

            this.users.Update(user);
            this.users.SaveChanges();
        }

        public void Delete(string id)
        {
            this.users.Delete(id);
            this.users.SaveChanges();
        }
    }
}
