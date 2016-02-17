namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RolesService : IRolesService
    {
        private IGenericRepository<IdentityUserRole> userRoles;
        private IGenericRepository<IdentityRole> roles;
        private IGenericRepository<User> users;

        public RolesService(
            IGenericRepository<IdentityUserRole> userRoles,
            IGenericRepository<IdentityRole> roles,
            IGenericRepository<User> users)
        {
            this.userRoles = userRoles;
            this.roles = roles;
            this.users = users;
        }

        public void AddRoleToUser(string userName, string roleName)
        {
            var role = this.roles.All()
                .FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                role = new IdentityRole
                {
                    Name = roleName
                };

                this.roles.Add(role);
                this.roles.SaveChanges();
            }

            var user = this.users.All().FirstOrDefault(u => u.UserName == userName);

            var userRole = this.userRoles.All()
                .FirstOrDefault(r => r.UserId == user.Id && r.RoleId == role.Id);

            if (userRole == null)
            {
                user.Roles.Add(new IdentityUserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });

                this.users.Update(user);

                this.users.SaveChanges();
            }
        }

        public IQueryable<string> GetRolesNamesByFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return this.roles.All()
                    .Select(r => r.Name);
            }

            return this.roles.All()
                .Where(r => r.Name.ToLower().Contains(filter.ToLower()))
                .Select(r => r.Name);
        }

        public IQueryable<IdentityRole> GetAll()
        {
            return this.roles.All();
        }

        public void RemoveRoleFromUser(string userName, string roleName)
        {
            var role = this.roles.All()
                   .FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                return;
            }

            var user = this.users.All().FirstOrDefault(u => u.UserName == userName);

            var userRole = this.userRoles.All()
                .FirstOrDefault(r => r.UserId == user.Id && r.RoleId == role.Id);

            this.userRoles.Delete(userRole);
            this.userRoles.SaveChanges();
        }

        public void Add(string name)
        {
            this.roles.Add(new IdentityRole
            {
                Name = name
            });

            this.roles.SaveChanges();
        }

        public void Remove(string name)
        {
            string id = this.roles.All().FirstOrDefault(r => r.Name == name).Id;

            this.roles.Delete(id);

            this.roles.SaveChanges();
        }
    }
}
