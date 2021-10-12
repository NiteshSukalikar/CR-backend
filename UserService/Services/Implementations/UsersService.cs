
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Enum;
using Shared.Helper;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserService.Common.StaticConstants;
using UserService.Model;
using UserService.Repository.UnitOfWorkAndBaseRepo;
using UserService.Services.Interfaces;
using UserService.ViewModel;

namespace UserService.Services.Implementations
{

    /// <summary>
    /// Defines the <see cref="UsersService" />
    /// </summary>
    public class UsersService : IUsersService
    {
        /// <summary>
        /// Defines the _unitOfWork
        /// </summary>
        internal IUnitOfWork _unitOfWork;
        private readonly CommonMethods _commonMethods;
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _commonMethods = new CommonMethods();
        }
              

        public async Task<ResponseModel> GetPatientByMob(string phone)
        {
            var response = new ResponseModel();
            try
            {
                PatientDetailsMobVM result = await _unitOfWork.PatientDetails.GetPatientByMob(phone);
                if (result != null)
                {
                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();
                    response.Data = result;
                    response.Message = IEHMessages.OperationSuccessful;
                }
                else
                {
                    response.StatusCode = ((int)StatusCode.StatusCode205).ToString();
                    response.Data = null;
                    response.Message = IEHMessages.UserNotFound;
                }

                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ((int)StatusCode.StatusCode205).ToString();
                response.Data = null;
                response.Message = IEHMessages.InternalServerError;
                return response;
            }
        }

    }
}

