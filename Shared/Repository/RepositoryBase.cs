using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Repository
{
    public class RepositoryBase<TClass> : IRepository<TClass> where TClass : class
    {
        #region Initialize Contructor
        private readonly DbContext context;
        private readonly DbSet<TClass> entities;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
            entities = context.Set<TClass>();
        }
        #endregion

        #region Generic Operations 
        /// <summary>
        /// Gets the first entity found or default value.
        /// </summary>
        /// <param name="filter">Filter expression for filtering the entities.</param>
        /// <param name="include">Include for eager-loading.</param>
        /// <returns></returns>
        public virtual TClass GetFirstOrDefault(Expression<Func<TClass, bool>> filter,
                                          params Expression<Func<TClass, object>>[] include)
        {
            IQueryable<TClass> dbQuery = SelectQuery(filter, include);
            return dbQuery.AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// Creates the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        public virtual void Create(TClass entity, params TClass[] entities)
        {
            EntityState state = EntityState.Added;
            SetEntityState(state, entity, entities);
        }


        /// <summary>
        /// Creates the specified entity/entities.
        /// </summary>
        /// <param name="entities">Multiple entities.</param>
        public void Create(TClass[] entities)
        {
            EntityState state = EntityState.Added;
            SetEntityStateForArray(state, entities);
        }

        /// <summary>
        /// Updates the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        public virtual void Update(TClass entity, params TClass[] entities)
        {
            EntityState state = EntityState.Modified;
            SetEntityState(state, entity, entities);
        }

        /// <summary>
        /// Saves a new entity of T or updates an in the context existing entity (if it's changed).
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TClass SaveOrUpdate(TClass entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Updates the specified entity/entities.
        /// </summary>
        /// <param name="entities">Multiple entities.</param>
        public virtual void Update(TClass[] entities)
        {
            EntityState state = EntityState.Modified;
            SetEntityStateForArray(state, entities);
        }

        /// <summary>
        /// Deletes the specified entity/entities.
        /// </summary>
        /// <param name="entity">Single entity.</param>
        /// <param name="entities">Multiple entities.</param>
        public virtual void Delete(TClass entity, params TClass[] entities)
        {
            EntityState state = EntityState.Deleted;
            SetEntityState(state, entity, entities);
        }

        /// <summary>
        /// Deletes the entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(object id)
        {
            TClass entity = CreateDbSet<TClass>().Find(id);
            EntityState state = EntityState.Deleted;
            SetEntityState(state, entity);
        }

        /// <summary>
        /// Deletes multiple entities which are found using filter.
        /// </summary>
        /// <param name="filter">Filter expression for filtering the entities.</param>
        public virtual void Delete(Expression<Func<TClass, bool>> filter)
        {
            IQueryable<TClass> dbQuery = SelectQuery(filter);
            dbQuery.AsNoTracking().ToList().ForEach(item => context.Entry(item).State = EntityState.Deleted);
        }

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        /// <returns>Number of rows affected.</returns>
        public int SaveChanges()
        {
            int recordsAffected = context.SaveChanges();
            //this.Dispose();  // uncommented by kundan for memeory release 
            return recordsAffected;
        }
        /// <summary>
        /// Fetch all records .
        /// </summary>
        /// <returns></returns>
        /// 
        public IQueryable<TClass> FetchAll()
        {
            return GetAll();
        }

        public IQueryable<TClass> GetAll()
        {
            return context.Set<TClass>();
        }

        public IQueryable<TClass> GetAll(Expression<Func<TClass, bool>> exp)
        {
            return context.Set<TClass>().Where(exp);
        }
        public TClass Get(Expression<Func<TClass, bool>> exp)
        {
            return context.Set<TClass>().Where(exp).FirstOrDefault();
        }

        public virtual TClass GetByID(object id)
        {
            return CreateDbSet<TClass>().Find(id);
        }


        #endregion

        //#region Stored Procedures Factory
        ////When you expect a model back (async)
        //public async Task<IList<TClass>> ExecWithStoreProcedureAsync(string query, params object[] parameters)
        //{
        //    // EF 6
        //    ////context.Database.SqlQuery<T>(query, parameters).ToListAsync();
        //    // EF Core
        //    return await entities.FromSql(query, parameters).ToListAsync();
        //}

        ////When you expect a model back
        //public IEnumerable<TClass> ExecWithStoreProcedure(string query)
        //{
        //    // EF 6
        //    ////_context.Database.SqlQuery<T>(query);
        //    // EF Core
        //    return entities.FromSql(query);
        //}

        ////When you expect a model back
        //public IEnumerable<TClass> ExecWithStoreProcedureWithParameters(string query, params object[] parameters)
        //{
        //    // EF 6
        //    ////_context.Database.SqlQuery<T>(query, parameters);
        //    // EF Core
        //    return entities.FromSql(query, parameters);
        //}

        ////When you expect a model back
        //public TClass ExecWithStoreProcedureWithParametersForModel(string query, params object[] parameters)
        //{
        //    // EF 6
        //    ////IEnumerable<TResult> dbQuery = _context.Database.SqlQuery<TResult>(query, parameters);
        //    ////return dbQuery.FirstOrDefault();
        //    // EF Core
        //    IEnumerable<TClass> dbQuery = entities.FromSql(query, parameters);
        //    return dbQuery.FirstOrDefault();
        //}

        //// Fire and forget (async)
        //public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        //{
        //    // EF 6
        //    ////await _context.Database.ExecuteSqlCommandAsync(query, parameters);
        //    // EF Core
        //    await context.Database.ExecuteSqlCommandAsync(query, default(CancellationToken), parameters);
        //}

        //// Fire and get no. of row inserted
        //public int ExecuteWithStoreProcedure(string query, params object[] parameters)
        //{
        //    return context.Database.ExecuteSqlCommand(query, parameters);
        //}
        //#endregion

        #region Dispose connection
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        ~RepositoryBase()
        {
            Dispose(false);
        }
        protected DbSet<TEntity> CreateDbSet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
        #endregion

        #region Private Methods
        private IQueryable<TClass> SelectQuery(Expression<Func<TClass, bool>> filter, Expression<Func<TClass, object>>[] include = null)
        {
            IQueryable<TClass> dbQuery = CreateDbSet<TClass>();

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            if (include != null)
            {
                dbQuery = include.Aggregate(dbQuery, (a, b) => a.Include(b));
            }
            return dbQuery;
        }

        private void SetEntityState(EntityState state, TClass entity, params TClass[] entities)
        {
            try
            {
                context.Entry(entity).State = state;
                foreach (TClass item in entities)
                {
                    context.Entry(item).State = state;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void SetEntityStateForArray(EntityState state, TClass[] entities)
        {
            try
            {
                foreach (TClass item in entities)
                {
                    context.Entry(item).State = state;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }
        #endregion Private Methods
    }
}
