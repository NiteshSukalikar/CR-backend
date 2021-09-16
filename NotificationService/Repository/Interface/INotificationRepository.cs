
using NotificationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Repository.Interfaces
{
   public interface INotificationRepository
   {
         PatientAppointmentDetailsModel GetAppointmentDetails(int AptId, int UserId);
        string SaveNotification(SendNotificationModel sendNotificationModel); 
        public List<NotificationModels> GetNotifications(PaginationModel pagination, long userId);


    }
}
