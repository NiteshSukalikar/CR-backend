using Microsoft.AspNetCore.Http;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Model;
using UserService.ViewModel;

namespace UserService.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<PatientDetailsMobVM> GetPatientByMob(string phone);
        Task<OrganizationDetailsModel> GetOrganizationList();
        Task<OrganizationModel> GetOrganization(int id);
        Task<OrganizationModel> SaveOrganization(UserDetailsModel userDetailsModel);
        Task<OrganizationModel> UpdateOrganization(OrganizationModel organizationModel);
    }
}
