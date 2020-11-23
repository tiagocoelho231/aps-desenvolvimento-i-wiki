using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Repositories.Common.Entity
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity item)
        {
            _dbContext.Set<TEntity>().Add(item);
            _dbContext.SaveChanges();
        }

        public void Edit(TEntity item)
        {
            _dbContext.Set<TEntity>().Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual TEntity Find(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> List()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity item)
        {
            _dbContext.Set<TEntity>().Attach(item);
            _dbContext.Entry(item).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void RemoveById(TKey id)
        {
            TEntity item = Find(id);
            Remove(item);
        }
    }
}
