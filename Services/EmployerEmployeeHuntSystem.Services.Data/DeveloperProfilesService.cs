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
        private const double AcceptableSkillsMatchPercentage = 50.0;

        private IDbRepository<DeveloperProfile, string> developerProfiles;
        private ISkillsService skills;
        private IGithubService githubService;
        private IJobOffersService jobOffers;
        private IUsersService users;

        public DeveloperProfilesService(
            IDbRepository<DeveloperProfile, string> developerProfiles,
            IGithubService githubService,
            ISkillsService skills,
            IJobOffersService jobOffers,
            IUsersService users)
        {
            this.developerProfiles = developerProfiles;
            this.githubService = githubService;
            this.skills = skills;
            this.jobOffers = jobOffers;
            this.users = users;
        }

        public DeveloperProfile Create(string userId, string githubProfile, ICollection<string> topProjects)
        {
            string userName = this.GetUserNameFromGithubProfileLink(githubProfile);

            Dictionary<string, long> skills = this.githubService.GetAllLanguagesFromGithubReposForUser(userName);

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

        public DeveloperProfile Edit(string userId, string githubProfile, ICollection<string> topProjects, bool isAvailableForHire)
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

            developerProfile.IsAvailableForHire = isAvailableForHire;

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

        public IQueryable<DeveloperProfile> GetCandidatesForJobOffer(int jobOfferId)
        {
            var result = new List<DeveloperProfile>();

            var jobOffer = this.jobOffers.GetById(jobOfferId);
            var candidacies = jobOffer.Candidacies;

            var jobOfferRequirements = new HashSet<string>(jobOffer.RequiredSkills.Select(s => s.Name).ToList());

            foreach (var developer in this.developerProfiles.All().Where(d => d.IsAvailableForHire == true))
            {
                var developersSkillsNamesList = developer.Skills.Select(s => s.Name).ToList();

                var developersSkills = new HashSet<string>(developersSkillsNamesList);

                double skillsMatchCount = jobOfferRequirements.Intersect(developersSkills).Count();

                if ((skillsMatchCount / jobOfferRequirements.Count) * 100 >= AcceptableSkillsMatchPercentage)
                {
                    if (candidacies.Any(c => c.DeveloperProfileId == developer.Id && c.IsDeleted == false))
                    {
                        continue;
                    }

                    result.Add(developer);
                }
            }

            return result.AsQueryable();
        }

        private string GetUserNameFromGithubProfileLink(string githubProfile)
        {
            string userName = githubProfile.Split(new string[] { "github.com/" }, StringSplitOptions.RemoveEmptyEntries)[1];

            return userName;
        }
    }
}
