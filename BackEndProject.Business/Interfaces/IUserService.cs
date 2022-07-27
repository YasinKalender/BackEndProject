using BackEndProject.Business.Validation;
using BackEndProject.Entities.ORM.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
