using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL.Repositories.Base
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        internal MainContext ctx = new MainContext();

        public DbSet<TEntity> EntitySet
        {
            get
            {
                return ctx.Set<TEntity>();
            }
        }

        public Repository()
        {
            ctx.Configuration.ProxyCreationEnabled = false;
        }

        public IQueryable<TEntity> GetAll()
        {
            return EntitySet;
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public virtual void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void UpdateFromOtherEntity(TEntity entity, TEntity otherEntity)
        {
            ctx.Entry(entity).CurrentValues.SetValues(otherEntity);
            Update(entity);
        }

        public void Commit()
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void AddRange(List<TEntity> objs)
        {
            ctx.Set<TEntity>().AddRange(objs);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public void LogQueries()
        {
            ctx.Database.Log = Console.Write;
        }
    }
}
