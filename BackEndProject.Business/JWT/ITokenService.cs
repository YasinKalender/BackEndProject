using BackEndProject.Entities.ORM.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.JWT
{
    public interface ITokenService
    {
        JwtToken CreateToken(User userApp, List<OperationClaim> operationClaims);
    }
}
