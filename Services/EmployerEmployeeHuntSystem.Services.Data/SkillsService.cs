namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class SkillsService : ISkillsService
    {
        private IDbRepository<Skill, int> skills;

        public SkillsService(IDbRepository<Skill, int> skills)
        {
            this.skills = skills;
        }

        public Skill Add(string name)
        {
            Skill newSkill = new Skill
            {
                Name = name
            };

            this.skills.Add(newSkill);
            this.skills.Save();

            return newSkill;
        }

        public void Delete(int id)
        {
            Skill skill = this.skills.GetById(id);

            this.skills.Delete(skill);
            this.skills.Save();
        }

        public Skill Edit(int id, string name)
        {
            Skill skill = this.skills.GetById(id);

            skill.Name = name;

            this.skills.Update(skill);
            this.skills.Save();
            return skill;
        }

        public IQueryable<Skill> GetAll()
        {
            return this.skills.All();
        }

        public IQueryable<string> GetAllSkillsNames(string filter)
        {
            return this.skills.All()
                .Where(s => s.Name.ToLower().Contains(filter.ToLower()))
                .Select(s => s.Name);
        }

        public Skill GetById(int id)
        {
            return this.skills.GetById(id);
        }

        public Skill GetByName(string name)
        {
            return this.skills.All().Where(s => s.Name == name).FirstOrDefault();
        }

        public IQueryable<Skill> GetDeleted()
        {
            return this.skills.AllWithDeleted()
                    .Where(s => s.IsDeleted == true);
        }

        public Skill Restore(int id)
        {
            Skill skill = this.skills.AllWithDeleted()
                    .FirstOrDefault(s => s.Id == id);

            skill.IsDeleted = false;

            this.skills.Update(skill);
            this.skills.Save();

            return skill;
        }
    }
}
