namespace EmployerEmployeeHuntSystem.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models;

    // TODO: Why BaseModel<int> instead BaseModel<TKey>?
    public class DbRepository<T, TKey> : IDbRepository<T, TKey>
        where T : BaseModel<TKey>
    {
        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "DbContext");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; set; }

        private DbContext Context { get; set; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(TKey id)
        {
            return this.All().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
