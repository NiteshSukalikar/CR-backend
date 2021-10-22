namespace AuthService.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Data;
    using Microsoft.Data.SqlClient;
    using IEH_Shared.Model;
    using AuthService.Repository.Interfaces;
    using AuthService.Infrastructure.DataAccess;
    using AuthService.Model;
    using AuthService.Common.StaticConstants;
    using Shared.Model;
    using IEH_Shared.Utility;

    /// <summary>
    /// Defines the <see cref="UserRepository" />
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        /// <summary>
        /// Defines the _IEHDbContext
        /// </summary>
        protected readonly IEHDbContext _IEHDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="IEHDbContext">The IEHDbContext<see cref="IEHDbContext"/></param>
        public AuthRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
        }

        public async Task<UserDetails> GetUserDetailsById(string userId)
        {
            SqlParameter[] param = {
                new SqlParameter("@Id", userId),
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserById, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
        public List<RolePermissionsModel> GetRolePermissions(int roleId)
        {
            try
            {
                SqlParameter[] param = {
                            new SqlParameter("@RoleId",roleId)
                        };
                var connection = _IEHDbContext.GetDbConnection();
                List<RolePermissionsModel> result = new List<RolePermissionsModel>();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetRolePermission, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<RolePermissionsModel>(reader).ToList();
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
                throw ex;
            }
        }

        public async Task<UserDetails> GetUserDetailsbyMRN(string mrn)
        {
            SqlParameter[] param = {
                new SqlParameter("@Mrn", mrn),
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserByMrn, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
        public string resetPasswordForgot(ResetPassword resetPassword)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@UserId", resetPassword.UserId),
                new SqlParameter("@Password",resetPassword.Password)
                ,outParam

            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.ResetPassword, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        resetPassword.ResponseResult = (string)outParam.Value;

                        return resetPassword.ResponseResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public string ChangePassword(ChangePassword password, TokenClaimsModal claims)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@OldPassword", password.OldPassword), 
                new SqlParameter("@NewPassword",password.NewPassword),
                new SqlParameter("@UserId", claims.UserId),
                outParam
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.ChangePassword, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        string responseCode = (string)outParam.Value;
                        return responseCode;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public string ActivateUser(UserDetails userDetails)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id", userDetails.UserId),
                new SqlParameter("IsActivated",userDetails.isActivated)
                ,outParam

            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.ActivateUser, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        userDetails.ResponseResult = (string)outParam.Value;

                        return userDetails.ResponseResult;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public async Task<UserDetails> GetUserDetailsByEmail(string email)
        {
            SqlParameter[] param = {
                new SqlParameter("@Email", email)
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserByEmail, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
        public async Task<UserDetails> GetUserByEmail(string email)
        {
            SqlParameter[] param = {
                new SqlParameter("@Email", email)
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserByEmail, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public async Task<string> UpdateDeviceTokenByUserId(string deviceToken, string userId)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@DeviceToken", deviceToken),
                new SqlParameter("@UserId", userId),
                outParam
            };
            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                SqlHelper.ExecuteProcedureReturnString(Constants.DbConn, SpConstants.UpdateDeviceTokenByUserId, param);
                return (string)outParam.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public async Task<UserDetails> GetUserDetailsByEmailAndRoleId(string email, string userType)
        {
            SqlParameter[] param = {
                new SqlParameter("@Email", email.ToLower()),
                new SqlParameter("@UserType", userType),
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserByEmailAndRoleId, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public async Task<UserDetails> GetUserDetailsForLogin(LoginModel loginVM)
        {
            SqlParameter[] param = {
                new SqlParameter("@Email", loginVM.Email.ToLower()),
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.GetUserDetailsForLogin, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        UserDetails LastLoginDetail = null;
                        LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public async Task<UserDetails> CheckIfUserAccountIsLocked(LoginModel loginVM)
        {
            SqlParameter[] param = {
                new SqlParameter("@Email", loginVM.Email.ToLower())
            };

            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                using (var cmd = connection.CreateCommand())
                {
                    _IEHDbContext.AddParametersToDbCommand(SpConstants.CheckIfUserAccountIsLocked, param, cmd);
                    using (var reader = cmd.ExecuteReader())
                    {
                        UserDetails LastLoginDetail = null;
                        LastLoginDetail = _IEHDbContext.DataReaderMapToList<UserDetails>(reader).FirstOrDefault();
                        return LastLoginDetail;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }


        public string loginLog(LoginLogs model)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@CreatedDate", model.CreatedDate),
                new SqlParameter("@CreatedById", model.CreatedById),
                new SqlParameter("@Action", model.Action),
                new SqlParameter("@IpAddress", model.IPAddress),
                new SqlParameter("@OrganizationId", model.OrganizationID),
                new SqlParameter("@LoginAttempt", model.LoginAttempt),
                new SqlParameter("@Country",model.Country),

                outParam
            };
            var connection = _IEHDbContext.GetDbConnection();
            try
            {
                SqlHelper.ExecuteProcedureReturnString(Constants.DbConn, SpConstants.addLoginLogs, param);
                return (string)outParam.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
    }
}
