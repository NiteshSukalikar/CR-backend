
using NotificationService.Model;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Services.Interfaces
{
    public interface INotificationService
    {
        PatientAppointmentDetailsModel GetAppointmentDetails(int AptId, int UserId);

        ResponseModel SaveNotification(SendNotificationModel sendNotificationModel);
        public ResponseModel GetNotifications(PaginationModel paginationModel,long userId);
        public Task<bool> SendPushNotification(string deviceToken, string title, int notificationTypeId, string notificationMessage, int badgeCount, bool defaultSoundOnOff, SendNotificationModel data);


    }
}
