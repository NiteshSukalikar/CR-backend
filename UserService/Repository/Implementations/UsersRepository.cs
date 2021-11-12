
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
using UserService.Model;

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

        public async Task<OrganizationModel> GetOrganization(int id)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Id",id)
                };
                var connection = _IEHDbContext.GetDbConnection();
                OrganizationModel result = new OrganizationModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetOrganization, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<OrganizationModel>(reader).FirstOrDefault();
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

        public async Task<OrganizationDetailsModel> GetOrganizationList()
        {
            try
            {
                SqlParameter[] param = { };
                var connection = _IEHDbContext.GetDbConnection();
                OrganizationDetailsModel result = new OrganizationDetailsModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.GetOrganizationList, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result.organizations = _IEHDbContext.DataReaderMapToList<OrganizationModel>(reader).ToList();
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

        public async Task<OrganizationModel> SaveOrganization(UserDetailsModel organizationModel)
        {
            try
            {
                var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param = {
                    new SqlParameter("@OrganizationsName",organizationModel.OrganizationsName),
                    new SqlParameter("@BusinessName",organizationModel.BusinessName),
                    new SqlParameter("@SubDomainName",organizationModel.SubDomainName),
                    new SqlParameter("@LogoName",organizationModel.LogoName),
                    new SqlParameter("@FaviconName",organizationModel.FaviconName),
                    new SqlParameter("@UserID",organizationModel.UserID),
                    new SqlParameter("@Address",organizationModel.Address),
                    new SqlParameter("@EmailAddress",organizationModel.EmailAddress),
                    new SqlParameter("@PrimaryContactNumber",organizationModel.PrimaryContactNumber),
                    new SqlParameter("@SecondaryContactNumber",organizationModel.SecondaryContactNumber),
                    new SqlParameter("@StateID",organizationModel.StateID),
                    new SqlParameter("@CountryID",organizationModel.CountryID),
                    new SqlParameter("@OrganizationTypesId",organizationModel.OrganizationTypesId),
                    new SqlParameter("@IsActive",organizationModel.IsActive),
                    new SqlParameter("@IsDeleted",organizationModel.IsDeleted),
                    outParam
                };
                var connection = _IEHDbContext.GetDbConnection();
                OrganizationModel result = new OrganizationModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.SaveOrganization, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<OrganizationModel>(reader).FirstOrDefault();
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

        public async Task<OrganizationModel> UpdateOrganization(OrganizationModel organizationModel)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@OrganizationsName",organizationModel.OrganizationsName),
                    new SqlParameter("@BusinessName",organizationModel.BusinessName),
                    new SqlParameter("@SubDomainName",organizationModel.SubDomainName),
                    new SqlParameter("@LogoName",organizationModel.LogoName),
                    new SqlParameter("@FaviconName",organizationModel.FaviconName),
                    new SqlParameter("@UserID",organizationModel.UserID),
                    new SqlParameter("@Address",organizationModel.Address),
                    new SqlParameter("@EmailAddress",organizationModel.EmailAddress),
                    new SqlParameter("@PrimaryContactNumber",organizationModel.PrimaryContactNumber),
                    new SqlParameter("@SecondaryContactNumber",organizationModel.SecondaryContactNumber),
                    new SqlParameter("@StateID",organizationModel.StateID),
                    new SqlParameter("@CountryID",organizationModel.CountryID),
                    new SqlParameter("@OrganizationTypesId",organizationModel.OrganizationTypesId),
                    new SqlParameter("@IsActive",organizationModel.IsActive),
                    new SqlParameter("@IsDeleted",organizationModel.IsDeleted)
                };
                var connection = _IEHDbContext.GetDbConnection();
                OrganizationModel result = new OrganizationModel();
                try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    using (var cmd = connection.CreateCommand())
                    {
                        _IEHDbContext.AddParametersToDbCommand(SpConstants.UpdateOrganization, param, cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            result = _IEHDbContext.DataReaderMapToList<OrganizationModel>(reader).FirstOrDefault();
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





