namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RolesDataImporter : IDataImporter
    {
        public void SeedData(EmployerEmployeeHuntDbContext context)
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
}
