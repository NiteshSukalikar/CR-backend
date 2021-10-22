
using AuthService.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class UserDataModel
    {
        public string refreshToken { get; set; }
        public string AccessToken { get; set; }
       
        public JObject Claims { get; set; }

        public string auth_token { get; set; }
        public List<RolePermissionsModel> rolePermissions { get; set; }
    }

    //public class Claims
    //{
    //    public string userId { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //}
}
