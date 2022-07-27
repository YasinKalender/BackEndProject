using BackEndProject.Entities.ORM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.DAL.Repositories
{
    public interface IBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> Include(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
        T GetOne(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        Task<bool> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
