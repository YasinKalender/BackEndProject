using BackEndProject.Business.Interfaces;
using BackEndProject.DAL.Context;
using BackEndProject.DAL.Repositories;
using BackEndProject.DAL.UnitOfWorks;
using BackEndProject.Entities.ORM.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.Services
{
    public class UserManager : BaseManager<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(UnitOfWork unitOfWork) :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IBaseRepository<UserOperationClaim> _userOperationClaimRepository
        {

            get
            {

                return _unitOfWork.GetBaseRepository<UserOperationClaim>();
            }
        }

        private IBaseRepository<OperationClaim> _operationClaimRepository
        {

            get
            {

                return _unitOfWork.GetBaseRepository<OperationClaim>();
            }
        }

        private IBaseRepository<User> _userRepository
        {

            get
            {

                return _unitOfWork.GetBaseRepository<User>();
            }
        }

        public List<OperationClaim> GetOperationClaims(User user)
        {

            return _userRepository.GetAll().Join(_userOperationClaimRepository.GetAll(), users => user.Id, uoc => uoc.UserId, (userResult, uocResult) => new
            {
                userResult = userResult,
                uocResult = uocResult


            }).Join(_operationClaimRepository.GetAll(), twotableresult => twotableresult.uocResult.OperationClaimId, oc => oc.Id, (twotableresults, ocs) => new
            {

                twotableresults = twotableresults,
                ocs = ocs

            }).Where(i => i.twotableresults.userResult.Id == user.Id).Select(i => new OperationClaim
            {
                Id=i.ocs.Id,
                Name=i.ocs.Name
                

            }).ToList();


        }

    

     
    }
}
