namespace EmployerEmployeeHuntSystem.Data.Migrations
{
    using System;
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
            this.SeedSkills(context);
            this.SeedOrganizations(context);
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

        private void SeedSkills(EmployerEmployeeHuntDbContext context)
        {
            if (!context.Skills.Any())
            {
                context.Skills.Add(new Skill { Name = "C#" });
                context.Skills.Add(new Skill { Name = "JavaScript" });
                context.Skills.Add(new Skill { Name = "Java" });
                context.Skills.Add(new Skill { Name = "HTML" });
                context.Skills.Add(new Skill { Name = "CSS" });
                context.Skills.Add(new Skill { Name = "Objective-C" });
                context.Skills.Add(new Skill { Name = "Swift" });
                context.Skills.Add(new Skill { Name = "XAML" });
                context.Skills.Add(new Skill { Name = "C" });
                context.Skills.Add(new Skill { Name = "C++" });

                context.SaveChanges();
            }
        }

        private void SeedOrganizations(EmployerEmployeeHuntDbContext context)
        {
            if (!context.Organizations.Any())
            {
                var allUsers = context.Users.ToList();

                foreach (var user in allUsers)
                {
                    var organization = new Organization
                    {
                        Name = string.Format("Organization of {0}", user.UserName),
                        FoundedOn = DateTime.Now,
                        Founder = user
                    };

                    context.Organizations.Add(organization);
                }

                context.SaveChanges();
            }
        }
    }
}
