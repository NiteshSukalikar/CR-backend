
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using NotificationService.Model;
using Shared.Model;
using NotificationService.Common.StaticConstants;
using NotificationService.Infrastructure.DataAccess;
using NotificationService.Repository.Interfaces;

namespace NotificationService.Repository.Implementations
{
    public class CallRepository : ICallRepository
    {
        protected readonly IEHDbContext _IEHDbContext;

        public CallRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
        }
        public ResponseModel CallConnectedUser(CallNotificationModel callConnectedUserModel)
        {
            try
            {
                ResponseModel res = new ResponseModel();
                string result;
                var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param = {
                    new SqlParameter("@Id",callConnectedUserModel.Id),
                    new SqlParameter("@ConnectionId",callConnectedUserModel.ConnectionId),
                    new SqlParameter("@UserId",callConnectedUserModel.UserId),
                    new SqlParameter("@CreatedDate",DateTime.UtcNow),
                   
                    outParam


                };
                var connection = _IEHDbContext.GetDbConnection();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.SaveUpdateCallUser, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = (string)(outParam.Value.Equals(System.DBNull.Value) ? string.Empty : outParam.Value);
                            
                        }
                    }
                    res.Data = result;
                    res.StatusCode = IEHMessages.Ok;
                    return res;
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

        public CallNotificationModel GetCallConnectionId(int UserID)
        {
            try
            {

                SqlParameter[] param = {
                    new SqlParameter("@UserId",UserID),
                    
                };
                var connection = _IEHDbContext.GetDbConnection();
                List<CallNotificationModel> result = new List<CallNotificationModel>();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetCallConnectionId, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<CallNotificationModel>(reader).ToList();
                            reader.NextResult();

                        }
                    }
                    return result!=null & result.Count>1? result[0]:null;
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

        public CallDetails GetCallUserDetails(int AptId,int UserId)
        {
            try
            {

                SqlParameter[] param = {
                    new SqlParameter("@AptId",AptId),
                     new SqlParameter("@UserId",UserId),

                };
                var connection = _IEHDbContext.GetDbConnection();
                List<CallDetails> result = new List<CallDetails>();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetCallUserDetails, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<CallDetails>(reader).ToList();
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
    }
}
