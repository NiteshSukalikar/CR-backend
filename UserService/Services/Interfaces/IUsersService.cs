
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseModel> GetPatientByMob(string phone);
        Task<ResponseModel> GetOrganizationList();
        Task<ResponseModel> GetOrganization(int id);
        Task<ResponseModel> SaveOrganization(UserDetailsModel userDetailsModel);

        Task<ResponseModel> UpdateOrganization(OrganizationModel organizationModel);
    }
}
