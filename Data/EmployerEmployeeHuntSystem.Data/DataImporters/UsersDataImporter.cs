namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class UsersDataImporter : IDataImporter
    {
        private const string AdministratorUserName = "admin@admin.com";
        private const string AdministratorPassword = AdministratorUserName;

        private const string HeadhunterUserName = "headhunter@headhunter.com";
        private const string HeadhunterPassword = HeadhunterUserName;

        private const string DeveloperUserName = "developer@developer.com";
        private const string DeveloperPassword = DeveloperUserName;

        private const string EmployerUserName = "employer@employer.com";
        private const string EmployerPassword = EmployerUserName;

        public void SeedData(EmployerEmployeeHuntDbContext context)
        {
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

            for (int i = 0; i < 60; i++)
            {
                var currentUser = new User
                {
                    Email = string.Format("user_{0}@somemail.com", i + 1),
                    UserName = string.Format("user_{0}", i + 1)
                };

                userManager.Create(currentUser, currentUser.Email);

                if (i % 2 == 0)
                {
                    userManager.AddToRole(currentUser.Id, GlobalConstants.HeadhunterRoleName);
                }
                else
                {
                    userManager.AddToRole(currentUser.Id, GlobalConstants.UserRoleName);
                }
            }
        }
    }
}
