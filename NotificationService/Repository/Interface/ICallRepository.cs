
using NotificationService.Model;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Repository.Interfaces
{
   public interface ICallRepository
    {
        ResponseModel CallConnectedUser(CallNotificationModel callConnectedUserModel);
        CallNotificationModel GetCallConnectionId(int UserID);
        CallDetails GetCallUserDetails(int AptId, int UserId);

    }
}
