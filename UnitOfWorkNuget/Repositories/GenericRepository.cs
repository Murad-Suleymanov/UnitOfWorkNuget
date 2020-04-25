using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkNuget.Abstract;
using UnitOfWorkNuget.DbContexts;

namespace UnitOfWorkNuget.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        GenericDbContext dbContext;
        DbSet<TEntity> dbSet;

        public GenericRepository(GenericDbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public IQueryable<TEntity> AsQuaryable()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }

        public void Attach(TEntity entity)
        {
            dbSet.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                Attach(entity);

            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public void Update(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
