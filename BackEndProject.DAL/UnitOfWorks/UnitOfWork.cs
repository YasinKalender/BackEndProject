using BackEndProject.DAL.Context;
using BackEndProject.DAL.Repositories;
using BackEndProject.Entities.ORM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProjectContext _projectContext { get; set; }

        public UnitOfWork(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public void SaveChanges()
        {
            _projectContext.SaveChanges();
        }

        public Task SaveChangesAync()
        {
            return _projectContext.SaveChangesAsync();
        }

        public IBaseRepository<T> GetBaseRepository<T>() where T : class, new()
        {
            return new BaseRepository<T>(_projectContext);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing){

            if (!disposed)
            {
                if (disposing)
                {
                    _projectContext.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
