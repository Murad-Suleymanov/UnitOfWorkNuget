using System;
using System.Threading.Tasks;
using UnitOfWorkNuget.DbContexts;

namespace UnitOfWorkNuget.Abstract
{
    /// <summary>
    /// Container for Repository
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// DbContext class
        /// </summary>
        GenericDbContext AppDbContext { get; }

        /// <summary>
        /// Generic Repositories
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// Commit transaction
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
