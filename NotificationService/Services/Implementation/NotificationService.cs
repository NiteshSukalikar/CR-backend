
using Newtonsoft.Json;
using NotificationService.Common.StaticConstants;
using NotificationService.Model;
using NotificationService.Repository.UnitOfWorkAndBaseRepo;
using NotificationService.Services.Interfaces;
using Shared.Enum;
using Shared.Helper;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Services.Implementations
{
    public class NotificationServiceClass :INotificationService
    {
        internal IUnitOfWork _unitOfWork;
        private readonly CommonMethods _commonMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedularService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public NotificationServiceClass(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _commonMethods = new CommonMethods();
        }
        public PatientAppointmentDetailsModel GetAppointmentDetails(int APtId , int UserId)
        {
            PatientAppointmentDetailsModel data = new PatientAppointmentDetailsModel();
            try
            {
                 data = _unitOfWork.notification.GetAppointmentDetails( APtId, UserId);
                return data;
            }
            catch (Exception e)
            {

                return data;
            }

        }
        public ResponseModel SaveNotification(SendNotificationModel sendNotification)
        {
            ResponseModel response = new ResponseModel();
            try
            {
               var data = _unitOfWork.notification.SaveNotification(sendNotification);
                if (data == "201")
                {
                    response.Data = data;
                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();
                    response.Message = IEHMessages.SavedSuccessfully;
                    return response;
                }
            }
            catch (Exception)
            {

                return response;
            }
            return response;
        }
        public ResponseModel GetNotifications(PaginationModel pagination, long userId)
        {

            var response = new ResponseModel();
            try
            {
                List<NotificationModels> logs = new List<NotificationModels>();



                logs = _unitOfWork.notification.GetNotifications(pagination, userId);
                if (logs.Count > 0)
                {
                    response.Data = logs;
                    response.Message = IEHMessages.SavedSuccessfully;
                    response.StatusCode = ((int)StatusCode.StatusCode200).ToString();

                }
                else
                {
                    response.Data = null;
                    response.Message = IEHMessages.InternalServerError;
                    response.StatusCode = ((int)StatusCode.StatusCode500).ToString();
                }
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Message = IEHMessages.InternalServerError;
                response.StatusCode = ((int)StatusCode.StatusCode500).ToString();

                return response;
            }


        }
        public async Task<bool> SendPushNotification(string deviceToken,  string title, int notificationTypeId, string notificationMessage, int badgeCount, bool defaultSoundOnOff, SendNotificationModel data)
        {

            HttpResponseMessage result;
            try
            {
                var serverKey = "AAAAGCmPYks:APA91bE3sloVraXs0YnZKvzq3qpLwHfozbHyCg1h3hllPn-fCUPuIbC8rSgcRvd19CEeXc5BxwYpGWjpRRVCtB_w2nbfhN1dOa-1MHN8g8lDLeLC-Dp2kUpvH90hHZzKSfNVSjFCLenC";

                var FireBasePushNotificationsURL = "https://fcm.googleapis.com/fcm/send";
                string jsonMessage = string.Empty;
                if (true)
                {

                    var messageInformation = new
                    {
                        notification = new
                        {
                            title = title,
                            text = notificationMessage,
                            notificationTypeId = notificationTypeId,
                            content_available = true,
                            badge = badgeCount == 0 ? 1 : badgeCount,
                            sound = (defaultSoundOnOff == false) ? "" : "default",

                        },
                        data = data,
                        registration_ids = deviceToken
                    };
                    jsonMessage = JsonConvert.SerializeObject(messageInformation);
                }
                else
                {
                    var messageInformation = new
                    {
                        notification = new
                        {
                            title = title,
                            text = notificationMessage,
                            notificationTypeId = notificationTypeId,
                            badge = badgeCount == 0 ? 1 : badgeCount,
                            sound = (defaultSoundOnOff == false) ? "" : "default",
                        },
                        data = data,
                        registration_ids = deviceToken
                    };
                    jsonMessage = JsonConvert.SerializeObject(messageInformation);
                }
                //Object to JSON STRUCTURE => using Newtonsoft.Json;


                // Create request to Firebase API
                var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);
                request.Headers.TryAddWithoutValidation("Authorization", "key =" + serverKey);
                request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.StatusCode.ToString() == "OK" ? true : false;

        }

    }
}
