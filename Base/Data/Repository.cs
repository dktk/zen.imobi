using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Base.Data
{
    public abstract class Repository<TContext, TEntity> :
            IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private TContext _entities = Activator.CreateInstance<TContext>();
        public TContext Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>();

            return query;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includedPaths = null)
        {
            IQueryable<TEntity> query = _entities.Set<TEntity>();

            if (includedPaths.IsNotNull())
            {
                foreach (var includePath in includedPaths)
                {
                    query = query.Include(includePath);
                }
            }

            query = query.Where(predicate);
            
            return query;
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public int ExecuteQuery(string storeProcedureName, IEnumerable<SqlParameter> sqlParameters)
        {
            return 
                new SqlCaller(_entities.Database.Connection.ConnectionString)
                    .ExecuteNonQuery(storeProcedureName, sqlParameters);
        }
    }
}