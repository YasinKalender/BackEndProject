using BackEndProject.Business.Interfaces;
using BackEndProject.Common.Results;
using BackEndProject.Common.Results.DataResults;
using BackEndProject.DAL.Context;
using BackEndProject.DAL.UnitOfWorks;
using BackEndProject.Entities.ORM.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Services
{
    public class BaseManager<T> : IBaseService<T> where T : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResults> AddAsync(T entity)
        {
            await _unitOfWork.GetBaseRepository<T>().AddAsync(entity);
            await _unitOfWork.SaveChangesAync();
            return new Result(ResultStatus.Success);


        }

        public async Task<IResults> AddRangeAsync(IEnumerable<T> entities)
        {
            await _unitOfWork.GetBaseRepository<T>().AddRangeAsync(entities);
            await _unitOfWork.SaveChangesAync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IDataResult<bool>> FindAsync(Expression<Func<T, bool>> expression)
        {
            await _unitOfWork.GetBaseRepository<T>().FindAsync(expression);
            return new DataResult<bool>(true);

        }

        public async Task<IDataResult<List<T>>> GetAllAsync()
        {
            var data = await _unitOfWork.GetBaseRepository<T>().GetAll().ToListAsync();
            return new DataResult<List<T>>(data, ResultStatus.Success, true, "");
        }

        public async Task<IDataResult<List<T>>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            var data = await _unitOfWork.GetBaseRepository<T>().GetAll().Where(expression).ToListAsync();
            return new DataResult<List<T>>(data, ResultStatus.Success, true, "");
        }

        public async Task<IDataResult<T>> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.GetBaseRepository<T>().GetByIdAsync(id);
            return new DataResult<T>(data, ResultStatus.Success);
        }

        public async Task<IResults> RemoveAsync(T entity)
        {
            _unitOfWork.GetBaseRepository<T>().Remove(entity);
            await _unitOfWork.SaveChangesAync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IResults> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _unitOfWork.GetBaseRepository<T>().RemoveRange(entities);
            await _unitOfWork.SaveChangesAync();
            return new Result(ResultStatus.Success);
        }

        public async Task<IResults> UpdateAsync(T entity)
        {
            _unitOfWork.GetBaseRepository<T>().Update(entity);
            await _unitOfWork.SaveChangesAync();
            return new Result(ResultStatus.Success);
        }
    }
}
