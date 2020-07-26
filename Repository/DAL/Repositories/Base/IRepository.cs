using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Update(TEntity obj);
        void UpdateFromOtherEntity(TEntity entity, TEntity otherEntity);
        void Commit();
        void Add(TEntity obj);
        void Delete(Func<TEntity, bool> predicate);
    }
}
