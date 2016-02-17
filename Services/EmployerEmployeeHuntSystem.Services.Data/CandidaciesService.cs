namespace EmployerEmployeeHuntSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using EmployerEmployeeHuntSystem.Data.Common;
    using EmployerEmployeeHuntSystem.Data.Models;

    public class CandidaciesService : ICandidaciesService
    {
        private IDbRepository<Candidacy, int> candidacies;

        public CandidaciesService(IDbRepository<Candidacy, int> candidacies)
        {
            this.candidacies = candidacies;
        }

        public void Approve(int id)
        {
            Candidacy candidacy = this.candidacies.GetById(id);

            candidacy.IsApproved = true;

            this.candidacies.Update(candidacy);

            this.candidacies.Save();
        }

        public void Delete(int id)
        {
            Candidacy currentCandidacy = this.candidacies.GetById(id);

            this.candidacies.Delete(currentCandidacy);
            this.candidacies.Save();
        }

        public IQueryable<Candidacy> GetAll()
        {
            return this.candidacies.All();
        }

        public Candidacy GetById(int id)
        {
            return this.candidacies.GetById(id);
        }
    }
}
