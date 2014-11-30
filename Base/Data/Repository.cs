using System;
using System.Data.Entity;
using System.Linq;

namespace Base.Data
{
    public abstract class Repository<TContext, TEntity> :
            IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {

        private TContext _entities = new TContext();
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

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            
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
    }
}