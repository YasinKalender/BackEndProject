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
    public interface IUnitOfWork:IDisposable
    {
        public ProjectContext _projectContext { get; set; }
        public IBaseRepository<T> GetBaseRepository<T>() where T : class, new();
        void SaveChanges();
        Task SaveChangesAync();
    }
}
