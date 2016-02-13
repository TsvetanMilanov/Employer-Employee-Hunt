namespace EmployerEmployeeHuntSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Constants;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class EmployerEmployeeHuntDbContext : IdentityDbContext<User>
    {
        public EmployerEmployeeHuntDbContext()
            : base(DatabaseConstants.DbConnectionStringName, throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<DeveloperProfile> DeveloperProfiles { get; set; }

        public virtual IDbSet<HeadhunterProfile> HeadhunterProfiles { get; set; }

        public virtual IDbSet<Skill> Skills { get; set; }

        public virtual IDbSet<Project> Projects { get; set; }

        public virtual IDbSet<JobOffer> JobOffers { get; set; }

        public virtual IDbSet<Organization> Organizations { get; set; }

        public virtual IDbSet<Candidacy> Candidacies { get; set; }

        public static EmployerEmployeeHuntDbContext Create()
        {
            return new EmployerEmployeeHuntDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
