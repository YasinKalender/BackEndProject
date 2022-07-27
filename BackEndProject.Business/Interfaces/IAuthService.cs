using BackEndProject.Business.JWT;
using BackEndProject.Business.Validation;
using BackEndProject.Common.Results.DataResults;
using BackEndProject.DTOs.DTO.UserDTOs;
using BackEndProject.Entities.ORM.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Interfaces
{
    public interface IAuthService:IValidator<User>
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto, string password);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IDataResult<User> UserExist(string email);

        IDataResult<JwtToken> CreateToken(User user);
        List<OperationClaim> GetOperationClaims(User user);
    }
}
