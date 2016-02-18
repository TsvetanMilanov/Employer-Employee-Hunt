namespace EmployerEmployeeHuntSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataImporters;

    public sealed class Configuration : DbMigrationsConfiguration<EmployerEmployeeHuntDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EmployerEmployeeHuntDbContext context)
        {
            var dataImporters = new List<IDataImporter>();

            if (!context.Roles.Any())
            {
                dataImporters.Add(new RolesDataImporter());
            }
            else
            {
                return;
            }

            if (!context.Users.Any())
            {
                dataImporters.Add(new UsersDataImporter());
            }

            if (!context.Skills.Any())
            {
                dataImporters.Add(new SkillsDataImporter());
            }

            if (!context.Organizations.Any())
            {
                dataImporters.Add(new OrganizationsDataImporter());
            }

            if (!context.DeveloperProfiles.Any())
            {
                dataImporters.Add(new DeveloperProfilesDataImporter());
            }

            if (!context.JobOffers.Any())
            {
                dataImporters.Add(new JobOffersDataImporter());
            }

            foreach (var importer in dataImporters)
            {
                importer.SeedData(context);
            }
        }
    }
}
