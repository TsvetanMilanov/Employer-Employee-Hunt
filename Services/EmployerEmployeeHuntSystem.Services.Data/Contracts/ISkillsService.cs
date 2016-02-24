namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface ISkillsService
    {
        IQueryable<Skill> GetAll();

        IQueryable<string> GetAllSkillsNames(string filter);

        Skill GetById(int id);

        Skill GetByName(string name);

        Skill Add(string name);

        Skill Edit(int id, string name);

        void Delete(int id);
    }
}
