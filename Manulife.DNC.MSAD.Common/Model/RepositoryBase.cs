using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Manulife.DNC.MSAD.Common
{
    public class RepositoryBase<T, Context> : IRepository<T, Context> 
        where T : class
        where Context : DbContext
    {
        private Context dbContext;

        public RepositoryBase(Context _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public Context DbContext
        {
            get
            {
                return dbContext;
            }
        }

        public DbSet<T> Entities
        {
            get
            {
                return dbContext.Set<T>();
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public void Delete(T entity, bool isNeedSave = true)
        {
            Entities.Remove(entity);
            if (isNeedSave)
            {
                dbContext.SaveChanges();
            }
        }

        public T GetById(object id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity, bool isNeedSave = true)
        {
            Entities.Add(entity);
            if (isNeedSave)
            {
                dbContext.SaveChanges();
            }
        }

        public void Update(T entity, bool isNeedSave = true)
        {
            if (isNeedSave)
            {
                dbContext.SaveChanges();
            }
        }
    }
}
