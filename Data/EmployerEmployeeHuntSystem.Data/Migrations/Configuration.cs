namespace EmployerEmployeeHuntSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<EmployerEmployeeHuntDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmployerEmployeeHuntDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
        }

        private void SeedRoles(EmployerEmployeeHuntDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                var headhunterRole = new IdentityRole { Name = GlobalConstants.HeadhunterRoleName };
                var userRole = new IdentityRole { Name = GlobalConstants.UserRoleName };
                roleManager.Create(adminRole);
                roleManager.Create(headhunterRole);
                roleManager.Create(userRole);
            }
        }

        private void SeedUsers(EmployerEmployeeHuntDbContext context)
        {
            if (!context.Users.Any())
            {
                const string AdministratorUserName = "admin@admin.com";
                const string AdministratorPassword = AdministratorUserName;

                const string HeadhunterUserName = "headhunter@headhunter.com";
                const string HeadhunterPassword = HeadhunterUserName;

                const string DeveloperUserName = "developer@developer.com";
                const string DeveloperPassword = DeveloperUserName;

                const string EmployerUserName = "employer@employer.com";
                const string EmployerPassword = EmployerUserName;

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                var adminUser = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName
                };

                var headhunterUser = new User
                {
                    UserName = HeadhunterUserName,
                    Email = HeadhunterUserName
                };

                var developerUser = new User
                {
                    UserName = DeveloperUserName,
                    Email = DeveloperUserName
                };

                var employerUser = new User
                {
                    UserName = EmployerUserName,
                    Email = EmployerUserName
                };

                userManager.Create(adminUser, AdministratorPassword);
                userManager.Create(headhunterUser, HeadhunterPassword);
                userManager.Create(developerUser, DeveloperPassword);
                userManager.Create(employerUser, EmployerPassword);

                userManager.AddToRole(adminUser.Id, GlobalConstants.AdministratorRoleName);
                userManager.AddToRole(headhunterUser.Id, GlobalConstants.HeadhunterRoleName);
                userManager.AddToRole(developerUser.Id, GlobalConstants.UserRoleName);
                userManager.AddToRole(employerUser.Id, GlobalConstants.UserRoleName);
            }
        }
    }
}
