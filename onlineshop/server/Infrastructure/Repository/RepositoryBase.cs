namespace Infrastructure.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public RepositoryBase(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        protected DatabaseContext DatabaseContext { get; set; }

        public void Create(T entity)
        {
            this.DatabaseContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.DatabaseContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.DatabaseContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.DatabaseContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.DatabaseContext.Set<T>().Update(entity);
        }
    }
}
