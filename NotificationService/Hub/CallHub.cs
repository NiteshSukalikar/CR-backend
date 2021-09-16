
using Microsoft.AspNetCore.SignalR;
using NotificationService.Model;
using NotificationService.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace IEH_Schedular.Hubs
{
    public class CallHub : Hub
    {
        private readonly ICallService _callService;
        private readonly INotificationService _notificationService;
        // protected readonly IEHDbContext _IEHDbContext;
        public CallHub(ICallService callService,INotificationService notificationService)
        {
            _callService = callService;
            _notificationService = notificationService;
            // _IEHDbContext = IEHDbContext;
        }
        public void Connect(int userId)
        {
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                CallNotificationModel callNotificationModel = new CallNotificationModel
                {
                    ConnectionId = Context.ConnectionId,
                    UserId = userId
                };
                _callService.CallConnectedUser(callNotificationModel);
            }
            catch (Exception ex)
            {
                //  logger.Error(ex, ex.Message);
            }
        }
        public void SendCallNotification(int UserId, int AptId)
        {
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                
                CallDetails callDetails = _callService.GetCallUserDetails(AptId, UserId);
                // var AppDetails = _context.PatientAppointment.Where(x => x.Id == AptId).FirstOrDefault();
                // var doctordetails = _context.Staffs.Where(x => x.UserID == UserId).FirstOrDefault();
                //var patientdetails = _context.Patients.Where(x => x.UserID == UserId).FirstOrDefault();
                string PInitiatorName = string.Empty; string SInitiatorName = string.Empty;
                long patientId = 0;
                if (callDetails != null)
                {
                    patientId = callDetails.PatientId;
                    SInitiatorName = callDetails.StaffName;
                    PInitiatorName = callDetails.PatientName;

                    CallNotificationModel connection;
                    if (String.IsNullOrEmpty(PInitiatorName))//If provider/staff logged in applcation,notification will send to patient userid
                    {
                        long userId = callDetails.PatUserId;//callDetails.PatUserId;//Convert.ToInt32(_context.Patients.Where(b => b.Id == AppDetails.PatientID).Select(b => b.UserID).FirstOrDefault());
                        connection = _callService.GetCallConnectionId((int)userId);
                        if (connection != null && UserId != userId)
                        {
                            Clients.Client(connection.ConnectionId).SendAsync("ReceiveCall", AptId, SInitiatorName, patientId, callDetails.StartDateTime, callDetails.EndDateTime);
                        }
                    }
                    else
                    {

                        long userId = callDetails.ProviderID;//callDetails.ProviderID; //_context.Staffs.Where(b => b.Id == AppDetails.Id).Select(b => b.UserID).FirstOrDefault();
                        connection = _callService.GetCallConnectionId((int)userId);
                        if (connection != null && UserId != userId)
                        {
                            Clients.Client(connection.ConnectionId).SendAsync("ReceiveCall", AptId, PInitiatorName, patientId, callDetails.StartDateTime, callDetails.EndDateTime);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
            }
        }
        public void SendNotification(SendNotificationModel notifications)
        {
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
               // CallDetails callDetails = _callService.GetCallUserDetails(AptId, UserId);


               
                if (notifications != null)
                {
                    var data = _notificationService.SaveNotification(notifications);

                    CallNotificationModel connection;
                    long userId = Convert.ToInt64(notifications.UserID);//callDetails.PatUserId;//Convert.ToInt32(_context.Patients.Where(b => b.Id == AppDetails.PatientID).Select(b => b.UserID).FirstOrDefault());
                    connection = _callService.GetCallConnectionId((int)userId);
                    List<NotificationModels> logs = new List<NotificationModels>();
                    PaginationModel pagination = new PaginationModel();
                    pagination.pageIndex = 1;
                    pagination.pageSize = 10;
                    pagination.searchText = "";
                    var response = _notificationService.GetNotifications(pagination, userId);
                    
                   // if (data.Data == "201")//If provider/staff logged in applcation,notification will send to patient userid
                    {
                       
                        if (connection != null)
                        {
                            var devicetoken = "d4cOnrkw8ERPoziwreXPSP:APA91bFhuchsrAnQjx5hrFxXGZy1jNsr4bU5LI3mKjs06nY-UJ1f4C_hSsmXCtwh5VKWvJYtHCYX_XZZo-1dNR8uj5QZc7plIlhZY9VUI1fukrFFPFS7HvGflZTjqmXPrYJTIjy6vqqV";


                            var resp = _notificationService.SendPushNotification(devicetoken,    notifications.NotificationTitle,  0,  notifications.Description,  1,  false,  notifications);
                            Clients.Client(connection.ConnectionId).SendAsync("GetNotification", response.Data);
                        }
                    }
                   

                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
            }
        }
    }

}
