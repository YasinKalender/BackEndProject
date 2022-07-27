using BackEndProject.Business.Interfaces;
using BackEndProject.Business.JWT;
using BackEndProject.Business.MappingHelpers;
using BackEndProject.Business.Validation;
using BackEndProject.Common.Helpers.HashingHelpers;
using BackEndProject.Common.Results;
using BackEndProject.Common.Results.DataResults;
using BackEndProject.Common.Results.StatusResult;
using BackEndProject.DAL.Context;
using BackEndProject.DAL.Repositories;
using BackEndProject.DAL.UnitOfWorks;
using BackEndProject.DTOs.DTO.UserDTOs;
using BackEndProject.Entities.ORM.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Services
{
    public class AuthManager : IAuthService
    {
        private readonly ProjectContext _projectContext;
        private readonly IUnitOfWork _unitOfWork;
        ITokenService _tokenService;

        public AuthManager(ProjectContext projectContext, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _projectContext = projectContext;
            _unitOfWork = unitOfWork;
        }
        private IBaseRepository<User> _userRespoitory
        {
            get
            {
                return _unitOfWork.GetBaseRepository<User>();
            }

        }

        public IDataResult<JwtToken> CreateToken(User user)
        {
            var claims = GetOperationClaims(user);
            var token = _tokenService.CreateToken(user, claims);
            if (token == null)
                return new DataResult<JwtToken>(false);

            return new DataResult<JwtToken>(token, ResultStatus.Success);
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var user = UserExist(userLoginDto.Email);
            if (user.Data == null)
                return new ErrorDataResult<User>(null, ResultStatus.Error, false, "Kullanıcı bulunamadı");

            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(null, ResultStatus.Error, false, "Kullanıcı veya adı şifre yanlış");
            }

            return new SuccessDataResult<User>(user.Data, ResultStatus.Success, true, "");


        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            var userRegister = UserRegisterNameValidate(userRegisterDto);

            if (!userRegister)
            {
                return new ErrorDataResult<User>(null, ResultStatus.Error, false, "Kullanıcı adı en az 3 karakter olmak zorunda");
            }


            string validationMessage = "";
            var data = userRegisterDto.Map();
            if (Validate(data, out validationMessage))
            {
                return new ErrorDataResult<User>(null, ResultStatus.Error, false, "Kullanıcı adı zorunlu alandır");
            }



            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true


            };
            _userRespoitory.AddAsync(user);
            _unitOfWork.SaveChanges();

            return new DataResult<User>(user, ResultStatus.Success, true, "Kullanıcı başarılı ile eklendi");



        }

        public IDataResult<User> UserExist(string email)
        {
            var user = _projectContext.Users.Where(i => i.Email == email).FirstOrDefault();
            if (user == null)
                return new DataResult<User>(null, ResultStatus.Warning, false, "Kullanıcı bulunamadı");
            else
                return new DataResult<User>(user, ResultStatus.Warning, true, "Kullanıcı bulunamadı");


        }

        public List<OperationClaim> GetOperationClaims(User user)
        {

            return _projectContext.OperationClaims.Join(_projectContext.UserOperationClaims, operationClaim => operationClaim.Id, userOperationClaim => userOperationClaim.OperationClaimId, (operationClaims, userOperationClaims) => new
            {

                operationClaims = operationClaims,
                userOperationClaims = userOperationClaims,


            }).Join(_projectContext.Users, twoTableResult => twoTableResult.userOperationClaims.UserId, user => user.Id, (twoTableResults, users) => new
            {

                users = users,
                opertaionClaims = twoTableResults.operationClaims,
                userOperationClaim = twoTableResults.userOperationClaims,


            }).Where(i => i.users.Id == user.Id).Select(i => new OperationClaim
            {
                Id = i.opertaionClaims.Id,
                Name = i.opertaionClaims.Name


            }).ToList();
        }

        private bool UserRegisterNameValidate(UserRegisterDto userRegisterDto)
        {

            if (userRegisterDto.FirstName.Length < 3)
            {
                return false;
            }

            return true;


        }

        public bool Validate(User entity, out string validationMessage)
        {
            validationMessage = string.Empty;
            if (string.IsNullOrEmpty(entity.FirstName))
            {
                validationMessage = "Kullanıcı adı zorunlu alandır";
                return false;
            }

            return true;
        }
    }
}
