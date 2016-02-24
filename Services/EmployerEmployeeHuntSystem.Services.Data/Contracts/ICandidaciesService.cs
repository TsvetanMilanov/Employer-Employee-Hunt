namespace EmployerEmployeeHuntSystem.Services.Data.Contracts
{
    using System.Linq;
    using EmployerEmployeeHuntSystem.Data.Models;

    public interface ICandidaciesService
    {
        IQueryable<Candidacy> GetAll();

        IQueryable<Candidacy> GetApprovedForUser(string id);

        Candidacy GetById(int id);

        void Approve(int id);

        void Delete(int id);
    }
}
