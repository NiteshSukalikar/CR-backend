
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseModel> GetPatientByMob(string phone);
    }
}
