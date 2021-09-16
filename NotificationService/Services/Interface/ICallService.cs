using IEH_Shared.Model;
using NotificationService.Model;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Interfaces
{
  public interface ICallService
    {
        ResponseModel CallConnectedUser(CallNotificationModel callConnectedUserModel);
        CallNotificationModel GetCallConnectionId(int UserID);
        CallDetails GetCallUserDetails(int AptId, int UserId);
    }
}
