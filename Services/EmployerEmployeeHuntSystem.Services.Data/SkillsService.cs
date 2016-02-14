namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class SkillsService : ISkillsService
    {
        private IDbRepository<Skill, int> skills;

        public SkillsService(IDbRepository<Skill, int> skills)
        {
            this.skills = skills;
        }

        public IQueryable<Skill> GetAll()
        {
            return this.skills.All();
        }
    }
}
