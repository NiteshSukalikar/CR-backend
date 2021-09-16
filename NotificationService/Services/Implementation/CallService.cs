

using IEH_Shared.Model;
using NotificationService.Model;
using NotificationService.Repository.Interfaces;
using NotificationService.Repository.UnitOfWorkAndBaseRepo;
using NotificationService.Services.Interfaces;
using Shared.Helper;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Implementations
{
    public class CallService : ICallService
    {
        private readonly ICallRepository callrepository;
        private readonly IUnitOfWork unitWork;
        private readonly CommonMethods _commonMethods;

        public CallService(ICallRepository callRepository, IUnitOfWork unitOfWork)
        {
            callrepository = callRepository;
            unitWork = unitOfWork;
            _commonMethods = new CommonMethods();
        }
        public ResponseModel CallConnectedUser(CallNotificationModel callConnectedUserModel)
        {
            var response = unitWork.callRepo.CallConnectedUser(callConnectedUserModel);
            return response;
        }

        public CallNotificationModel GetCallConnectionId(int UserID)
        {
            var response = callrepository.GetCallConnectionId(UserID);
            return response;
        }

        public CallDetails GetCallUserDetails(int AptId,int UserId)
        {
            var response = callrepository.GetCallUserDetails(AptId,UserId);
            return response;
        }
    }
}
