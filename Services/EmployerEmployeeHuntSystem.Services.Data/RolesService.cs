namespace EmployerEmployeeHuntSystem.Services.Data
{
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
            return this.roles.All()
                .Where(r => r.Name.ToLower().Contains(filter.ToLower()))
                .Select(r => r.Name);
        }
    }
}
