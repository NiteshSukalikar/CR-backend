
using Microsoft.Data.SqlClient;
using NotificationService.Common.StaticConstants;
using NotificationService.Infrastructure.DataAccess;
using NotificationService.Model;
using NotificationService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Repository.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        protected readonly IEHDbContext _IEHDbContext;

        public NotificationRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
        }
        public PatientAppointmentDetailsModel GetAppointmentDetails(int aptid , int userId)
        {
            try
            {
                try
                {

                    SqlParameter[] param = {
                    new SqlParameter("@AptId",aptid),
                     new SqlParameter("@UserId",userId),

                    };
                    var connection = _IEHDbContext.GetDbConnection();
                    List<PatientAppointmentDetailsModel> result = new List<PatientAppointmentDetailsModel>();
                    try
                    {
                        if (connection.State == ConnectionState.Closed) { connection.Open(); }
                        using (var cmd = connection.CreateCommand())
                        {
                            _IEHDbContext.AddParametersToDbCommand(SpConstants.GetCallUserDetails, param, cmd);
                            using (var reader = cmd.ExecuteReader())
                            {
                                result = _IEHDbContext.DataReaderMapToList<PatientAppointmentDetailsModel>(reader).ToList();
                                reader.NextResult();

                            }
                        }
                        return result != null ? result[0] : null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public string SaveNotification(SendNotificationModel sendNotification)
        {
            try
            {
                try
                {
                    var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter[] param = {
                        new SqlParameter("@CreatedDate",DateTime.UtcNow),
                        new SqlParameter("@CreatedById",sendNotification.CreatedBy),
                        new SqlParameter("@Description",sendNotification.Description),
                        new SqlParameter("@GoToLink",sendNotification.GoToLink),
                        new SqlParameter("@ImageUrl",sendNotification.ImageUrl),
                        new SqlParameter("@IsActive",true),
                        new SqlParameter("@IsDeleted",false),
                        new SqlParameter("@NotificationTitle",sendNotification.NotificationTitle),
                        new SqlParameter("@OrganizationID",sendNotification.OrganizationID),
                        new SqlParameter("@isRead",sendNotification.IsRead),
                        new SqlParameter("@userId",sendNotification.UserID),
                        new SqlParameter("@isNotified",sendNotification.isNotified),
                        new SqlParameter("@NotificationType",sendNotification.NotificationType),


                     outParam
                    };
                    var connection = _IEHDbContext.GetDbConnection();
                   var  result =string.Empty;
                    try
                    {
                        if (connection.State == ConnectionState.Closed) { connection.Open(); }
                        using (var cmd = connection.CreateCommand())
                        {
                            _IEHDbContext.AddParametersToDbCommand(SpConstants.SaveNotification, param, cmd);
                            using (var reader = cmd.ExecuteReader())
                            {
                                result = (string)(outParam.Value.Equals(System.DBNull.Value) ? string.Empty : outParam.Value);
                                reader.NextResult();

                            }
                        }
                        return result;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public List<NotificationModels> GetNotifications(PaginationModel pagination, long userId)
        {

            try
            {

                SqlParameter[] param = {
                      new SqlParameter("@PageIndex",pagination.pageIndex),
                    new SqlParameter("@PageSize", pagination.pageSize),
                    new SqlParameter("@SearchText", pagination.searchText),
                    new SqlParameter("@userId",userId),
                };
                var connection = _IEHDbContext.GetDbConnection();
                try
                {
                    List<NotificationModels> notificationModels = new List<NotificationModels>();
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.USP_GetNotifications, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            notificationModels = _IEHDbContext.DataReaderMapToList<NotificationModels>(reader).ToList();
                            // patientAppointmentDetailsModel.Id=(Int16) (outParam.Value.Equals(System.DBNull.Value) ? string.Empty : outParam.Value);
                            return notificationModels;
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
