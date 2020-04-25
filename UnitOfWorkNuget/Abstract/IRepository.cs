using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWorkNuget.Abstract
{
    /// <summary>
    /// For operations on TEntity classes and for the separation of each class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adding TEntity objects
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Update TEntity objects
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Attach TEntity objects
        /// </summary>
        /// <param name="entity"></param>
        void Attach(TEntity entity);

        /// <summary>
        /// Delete TEntity objects
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Convert TEntity objects to IQueryble
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> AsQuaryable();

        /// <summary>
        /// Search for TEntity objects by search parameters
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
    }
}
