using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Manulife.DNC.MSAD.Common
{
    public interface IRepository<T, Context> 
        where T  : class
        where Context : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        Context DbContext { get; }

        /// <summary>
        /// 
        /// </summary>
        DbSet<T> Entities { get; }

        /// <summary>
        /// 
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// 通过主键ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        void Insert(T entity, bool isSave = true);

        void Update(T entity, bool isSave = true);

        void Delete(T entity, bool isSave = true);
    }
}
