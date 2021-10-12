namespace DashboardService.Repository.Implementations
{
   
    using System;
    using System.Data;
    using Microsoft.Data.SqlClient;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AuditLogVM = DashboardService.ViewModel.Shared.AuditLogVM;
    using IEH_Shared.Model;
    using DashboardService.Repository.Interfaces;
    using DashboardService.Infrastructure.DataAccess;
    using DashboardService.Model;
    using Shared.Model;
    using DashboardService.Common.StaticConstants;

    /// <summary>
    /// Defines the <see cref="DashboardRepository" />
    /// </summary>
    public class DashboardRepository : IDashboardRepository
    {
        protected readonly IEHDbContext _IEHDbContext;

        public DashboardRepository(IEHDbContext IEHDbContext)
        {
            _IEHDbContext = IEHDbContext;
        }

        public DashboardDataModel GetAdminDashboardDetails(FilterParameters filterModel, TokenClaimsModal claims)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@UserId",claims.UserId)
                };
                var connection = _IEHDbContext.GetDbConnection();
                DashboardDataModel result = new DashboardDataModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetProviderDashboardDetails, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result.DashboardList = _IEHDbContext.DataReaderMapToList<Dashboard>(reader).ToList();
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
