using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AngularJsAppEntityFramework.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        T FindOne(Expression<Func<T, bool>> predicate);

        T FindOne(Expression<Func<T, bool>> predicate, List<string> includeProperties);

        bool Exists(Expression<Func<T, bool>> predicate);

        IQueryable<T> AsQueryable();

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        int Save(T entity);

        int SaveAll(List<T> entity);
        int UpdateAll(List<T> entities);
        int Recreate(List<T> entity);

        int Recreate(List<T> oldEntities, List<T> newEntities);

        int SaveChanges();

        bool Delete(T entity);

        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add entity to DbSet
        /// </summary>
        /// <param name="entity">Entity to add in DbSet</param>
        void Add(T entity);

        /// <summary>
        /// Add entity collection to DbSet.
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void BlukInsert(IEnumerable<T> entities);
    }
}
