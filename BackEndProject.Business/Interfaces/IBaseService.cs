using BackEndProject.Common.Results;
using BackEndProject.Common.Results.DataResults;
using BackEndProject.Entities.ORM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Interfaces
{
    public interface IBaseService<T> where T : class, new()
    {
        Task<IDataResult<T>> GetByIdAsync(int id);
        Task<IDataResult<List<T>>> GetAllAsync();
        Task<IDataResult<List<T>>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<IDataResult<bool>> FindAsync(Expression<Func<T, bool>> expression);
        Task<IResults> AddAsync(T entity);
        Task<IResults> AddRangeAsync(IEnumerable<T> entities);
        Task<IResults> UpdateAsync(T entity);
        Task<IResults> RemoveAsync(T entity);
        Task<IResults> RemoveRangeAsync(IEnumerable<T> entities);

    }
}
