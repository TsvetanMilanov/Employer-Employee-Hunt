namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface ISkillsService
    {
        IQueryable<Skill> GetAll();
    }
}
