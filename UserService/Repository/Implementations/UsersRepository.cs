
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics.Tracing;
using Microsoft.AspNetCore.Http;
using static IEH_Shared.Model.ConstantString;
using System.Net;
using IEH_Shared.Model;

using UserService.Repository.Interfaces;
using UserService.ViewModel;
using Shared.Model;
using UserService.Common.StaticConstants;
using Shared.Helper;
using UserService.Infrastructure.DataAccess;

namespace UserService.Repository.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// Defines the _IEHDbContext
        /// </summary>
        protected readonly IEHDbContext _IEHDbContext;
        private readonly CommonMethods _commonMethods;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardRepository"/> class.
        /// </summary>
        /// <param name="IEHDbContext">The IEHDbContext<see cref="IEHDbContext"/></param>
        public UsersRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
            _commonMethods = new CommonMethods();
        }

        public async Task<PatientDetailsMobVM> GetPatientByMob(string phone)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@phone",phone)
                };
                var connection = _IEHDbContext.GetDbConnection();
                PatientDetailsMobVM result = new PatientDetailsMobVM();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetPatientByMob, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<PatientDetailsMobVM>(reader).FirstOrDefault();
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


    }
}





