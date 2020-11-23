using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Repositories.Common
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        List<TEntity> List();
        TEntity Find(TKey id);
        void Add(TEntity item);
        void Edit(TEntity item);
        void Remove(TEntity item);
        void RemoveById(TKey id);
    }
}
