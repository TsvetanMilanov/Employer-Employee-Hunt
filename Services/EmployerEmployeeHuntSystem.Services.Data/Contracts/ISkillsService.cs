namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface ISkillsService
    {
        IQueryable<Skill> GetAll();

        IQueryable<string> GetAllSkillsNames(string filter);

        Skill GetByName(string name);
    }
}
