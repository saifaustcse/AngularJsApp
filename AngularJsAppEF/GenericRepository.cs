using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAppEF
{
    public  class GenericRepository<T>  where T : class
    {
        //private readonly AngularJsDbContext context;
        //private readonly DbSet<T> dbSet;


        //protected GenericRepository(AngularJsDbContext context)
        //{
        //    this.context = context;
        //    dbSet = this.context.Set<T>();
        //}

        private readonly AngularJsDbContext context=new AngularJsDbContext();
        private readonly DbSet<T> dbSet;
        public GenericRepository()
        {
           
            dbSet = this.context.Set<T>();
        }


        public virtual IQueryable<T> All()
        {
            return dbSet.AsQueryable();
        }

        /// <summary>
        /// Find entity based on lamda-expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T FindOne(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public virtual T FindOne(Expression<Func<T, bool>> predicate, List<string> includeProperties)
        {
            IQueryable<T> query = dbSet.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var name in includeProperties)
                {
                    query = query.Include(name);
                }
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Check entity exists or not based on lamda-expression
        /// </summary>
        /// <param name="predicate">Expression to match</param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An System.Linq.IQueryable`1 that contains elements from the input sequence that 
        /// satisfy the condition specified by predicate.
        /// </returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }

        public virtual int Save(T entity)
        {
            DbEntityEntry<T> entry = context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                dbSet.Add(entity);
                entry.State = EntityState.Added;
            }
            else
            {
                dbSet.Attach(entity);
                entry.State = EntityState.Modified;
            }

            try
            {
                return context.SaveChanges();
            }
            catch
            {
                ClearEntityState();
                throw;
            }
        }



        public virtual int SaveAll(List<T> entity)
        {
            dbSet.AddRange(entity);
            return SaveChanges();
        }

        public virtual int UpdateAll(List<T> entities)
        {
            foreach (T entity in entities)
            {
                DbEntityEntry<T> entry = context.Entry(entity);

                dbSet.Attach(entity);
                entry.State = EntityState.Modified;
            }
            return SaveChanges();
        }

        public virtual int Recreate(List<T> entity)
        {
            DbSet<T> objects = dbSet;
            dbSet.RemoveRange(objects);
            dbSet.AddRange(entity);
            return SaveChanges();
        }

        public virtual int Recreate(List<T> oldEntities, List<T> newEntities)
        {
            dbSet.RemoveRange(oldEntities);
            dbSet.AddRange(newEntities);
            return SaveChanges();
        }

        public virtual bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// Will be used for DeleteALL
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> objects = Where(predicate);
            dbSet.RemoveRange(objects);
            return SaveChanges();
        }

        /// <summary>
        /// Save all changes in DbContext
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        private void ClearEntityState()
        {
            List<DbEntityEntry> changedEntries = context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        /// <summary>
        /// Add entity to DbSet. SaveChanges requires to update database.
        /// </summary>
        /// <param name="entity">Entity to add in DbSet</param>
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Add entity collection to DbSet. SaveChanges requires to update database.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        /// <summary>
        /// Remove entity from DbSet. SaveChanges requires to update database.
        /// </summary>
        /// <param name="entity">Entity to remove from DbSet</param>
        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }


        public virtual void BlukInsert(IEnumerable<T> entities)
        {
            bool autoDetectChangesEnabled = context.Configuration.AutoDetectChangesEnabled;
            bool validateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;

            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            dbSet.AddRange(entities);
            SaveChanges();

            context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            context.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
        }
    }
}
