using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class SaveLogUserSystem
    {
        public string SystemIPAddress { get; set; }
        public string OrganizationsToken { get; set; }
        public DateTime LogUserCreatedOn { get; set; }
    }
}
