using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkNuget.Abstract;
using UnitOfWorkNuget.DbContexts;

namespace UnitOfWorkNuget.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly string connectionStringName = null;
        Dictionary<Type, object> repolist = null;
        bool disposed = false;
        GenericDbContext dbContext = null;

        public UnitOfWork(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
            repolist = new Dictionary<Type, object>();
            dbContext = new GenericDbContext(connectionStringName);
        }


        public GenericDbContext AppDbContext => dbContext;

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Dispose();
            }

            disposed = true;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repolist.Keys.Contains(typeof(TEntity)))
                return repolist[typeof(TEntity)] as IRepository<TEntity>;

            var repo = new GenericRepository<TEntity>(dbContext);
            repolist.Add(typeof(TEntity), repo);

            return repo;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
