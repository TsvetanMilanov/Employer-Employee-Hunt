namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using System;
    using System.Linq;
    using Models;

    public class OrganizationsDataImporter : IDataImporter
    {
        public void SeedData(EmployerEmployeeHuntDbContext context)
        {
            var allUsers = context.Users.ToList();

            for (int i = 0; i < allUsers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }

                var user = allUsers[i];
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
