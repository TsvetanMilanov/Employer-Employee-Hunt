namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface ISkillsService
    {
        IQueryable<Skill> GetAll();

        IQueryable<Skill> GetDeleted();

        IQueryable<string> GetAllSkillsNames(string filter);

        Skill GetById(int id);

        Skill GetByName(string name);

        Skill Add(string name);

        Skill Edit(int id, string name);

        Skill Restore(int id);

        void Delete(int id);
    }
}
