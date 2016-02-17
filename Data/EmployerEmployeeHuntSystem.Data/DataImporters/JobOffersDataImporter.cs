namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Models;

    public class JobOffersDataImporter : IDataImporter
    {
        public void SeedData(EmployerEmployeeHuntDbContext context)
        {
            var random = new Random();

            var allOrganiazations = context.Organizations.ToList();
            var headhunterRole = context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.HeadhunterRoleName);

            var allHeadhunters = context.Users.Where(u => u.Roles.Any(r => r.RoleId == headhunterRole.Id)).ToList();

            var skills = context.Skills.ToList();

            for (int i = 0; i < allOrganiazations.Count; i++)
            {
                var organization = allOrganiazations[i];

                for (int j = 0; j < 5; j++)
                {
                    var user = allHeadhunters[i % allHeadhunters.Count];

                    var requiredSkills = this.GetRandomRequiredSkills(skills);

                    HeadhunterProfile headhunter = user.HeadhunterProfile;

                    if (headhunter == null)
                    {
                        headhunter = new HeadhunterProfile
                        {
                            User = user
                        };

                        context.HeadhunterProfiles.Add(headhunter);
                        context.SaveChanges();
                    }

                    var jobOffer = new JobOffer
                    {
                        Organization = organization,
                        Headhunter = headhunter,
                        RegistrationDate = DateTime.Now.AddDays(-100).AddDays(random.Next(0, 100)),
                        IsActive = j % 3 == 0 ? false : true,
                        RequiredSkills = requiredSkills
                    };

                    context.JobOffers.Add(jobOffer);
                }
            }

            context.SaveChanges();
        }

        private ICollection<Skill> GetRandomRequiredSkills(IList<Skill> skills)
        {
            Random random = new Random();
            var result = new List<Skill>();

            int count = random.Next(1, 8);

            for (int i = 0; i < count; i++)
            {
                var skill = skills[random.Next(0, skills.Count)];
                result.Add(skill);
            }

            return result;
        }
    }
}
