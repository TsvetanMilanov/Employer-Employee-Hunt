namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;
    using Web.Github;

    public class DeveloperProfilesService : IDeveloperProfilesService
    {
        private const int MinLinesOfCodeForSkill = 7000;

        private IDbRepository<DeveloperProfile, string> developerProfiles;
        private ISkillsService skills;
        private IGithubService githubSerice;

        public DeveloperProfilesService(
            IDbRepository<DeveloperProfile, string> developerProfiles,
            IGithubService githubSerice,
            ISkillsService skills)
        {
            this.developerProfiles = developerProfiles;
            this.githubSerice = githubSerice;
            this.skills = skills;
        }

        public DeveloperProfile Create(string userId, string githubProfile, ICollection<string> topProjects)
        {
            string userName = this.GetUserNameFromGithubProfileLink(githubProfile);

            Dictionary<string, long> skills = this.githubSerice.GetAllLanguagesFromGithubReposForUser(userName);

            var skillsNames = new List<string>();

            foreach (var skill in skills)
            {
                if (skill.Value >= MinLinesOfCodeForSkill)
                {
                    skillsNames.Add(skill.Key);
                }
            }

            var allDbSkills = this.skills.GetAll().ToList();
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
                GithubProfile = githubProfile,
                IsAvailableForHire = true,
                Skills = userSkills,
                Id = userId
            };

            foreach (var project in topProjects)
            {
                if (!string.IsNullOrWhiteSpace(project))
                {
                    // TODO: Add project name.
                    developerProfile.TopProjects.Add(new Project
                    {
                        Link = project,
                        Name = project
                    });
                }
            }

            this.developerProfiles.Add(developerProfile);
            this.developerProfiles.Save();

            return developerProfile;
        }

        public IQueryable<DeveloperProfile> GetAll()
        {
            return this.developerProfiles.All();
        }

        public DeveloperProfile GetById(string id)
        {
            return this.developerProfiles.GetById(id);
        }

        public DeveloperProfile Edit(string userId, string githubProfile, ICollection<string> topProjects)
        {
            DeveloperProfile developerProfile = this.developerProfiles.GetById(userId);

            developerProfile.GithubProfile = githubProfile;

            var developersCurrentTopProjects = developerProfile.TopProjects.ToList();

            foreach (var projectLink in topProjects)
            {
                if (!string.IsNullOrWhiteSpace(projectLink) && !developersCurrentTopProjects.Any(p => p.Link == projectLink))
                {
                    // TODO: Add functionality for custom project name.
                    developerProfile.TopProjects.Add(new Project
                    {
                        Link = projectLink,
                        Name = projectLink
                    });
                }
            }

            this.developerProfiles.Update(developerProfile);

            this.developerProfiles.Save();

            return developerProfile;
        }

        public void AddSkill(string userId, string name)
        {
            Skill skill = this.skills.GetByName(name);

            if (skill == null)
            {
                skill = new Skill
                {
                    Name = name
                };
            }

            DeveloperProfile developerProfile = this.developerProfiles.GetById(userId);

            developerProfile.Skills.Add(skill);

            this.developerProfiles.Update(developerProfile);

            this.developerProfiles.Save();
        }

        private string GetUserNameFromGithubProfileLink(string githubProfile)
        {
            string userName = githubProfile.Split(new string[] { "github.com/" }, StringSplitOptions.RemoveEmptyEntries)[1];

            return userName;
        }
    }
}
