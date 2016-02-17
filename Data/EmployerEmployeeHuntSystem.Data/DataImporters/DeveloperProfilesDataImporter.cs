namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Services.Web.Github;

    public class DeveloperProfilesDataImporter : IDataImporter
    {
        private const int MinLinesOfCodeForSkill = 7000;

        public void SeedData(EmployerEmployeeHuntDbContext context)
        {
            IGithubService githubService = new GithubService();

            var developersProfiles = new string[]
            {
                "https://github.com/TsvetanMilanov", "https://github.com/IvanMomchilov", "https://github.com/ivaylokenov", "https://github.com/NikolayIT"
            };

            var adminRole = context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.AdministratorRoleName);
            var headhunterRole = context.Roles.FirstOrDefault(r => r.Name == GlobalConstants.HeadhunterRoleName);

            var users = context.Users.Where(u => !u.Roles.Any(r => r.RoleId == adminRole.Id || r.RoleId == headhunterRole.Id)).ToList();

            for (int i = 0; i < developersProfiles.Length; i++)
            {
                var currentProfile = developersProfiles[i];

                string userId = string.Empty;

                if (i < users.Count)
                {
                    var currentUser = users[i];

                    userId = currentUser.Id;
                }
                else
                {
                    var userStore = new UserStore<User>(context);
                    var userManager = new UserManager<User>(userStore);

                    var newUser = new User
                    {
                        UserName = string.Format("developer_{0}", i),
                        Email = string.Format("developer_{0}@somemail.com", i)
                    };

                    userManager.Create(newUser, newUser.Email);
                    userManager.AddToRole(newUser.Id, GlobalConstants.UserRoleName);

                    userId = newUser.Id;
                }

                string userName = this.GetUserNameFromGithubProfileLink(currentProfile);

                Dictionary<string, long> skills = githubService.GetAllLanguagesFromGithubReposForUser(userName);

                var skillsNames = new List<string>();

                foreach (var skill in skills)
                {
                    if (skill.Value >= MinLinesOfCodeForSkill)
                    {
                        skillsNames.Add(skill.Key);
                    }
                }

                var allDbSkills = context.Skills.ToList();

                Dictionary<string, Skill> allDbSkillsWithNames = new Dictionary<string, Skill>();

                foreach (var skill in allDbSkills)
                {
                    allDbSkillsWithNames.Add(skill.Name, skill);
                }

                var userSkills = new List<Skill>();

                foreach (var skill in skillsNames)
                {
                    if (allDbSkillsWithNames.ContainsKey(skill))
                    {
                        userSkills.Add(allDbSkillsWithNames[skill]);
                    }
                    else
                    {
                        userSkills.Add(new Skill() { Name = skill });
                    }
                }

                DeveloperProfile developerProfile = new DeveloperProfile
                {
                    GithubProfile = currentProfile,
                    IsAvailableForHire = true,
                    Skills = userSkills,
                    Id = userId
                };

                context.DeveloperProfiles.Add(developerProfile);
                context.SaveChanges();
            }
        }

        private string GetUserNameFromGithubProfileLink(string githubProfile)
        {
            string userName = githubProfile.Split(new string[] { "github.com/" }, StringSplitOptions.RemoveEmptyEntries)[1];

            return userName;
        }
    }
}
