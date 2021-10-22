using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class LoginLogs
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CreatedById { get; set; }

        public string Action { get; set; }

        public string IPAddress { get; set; }

        public int? OrganizationID { get; set; }

        public string LoginAttempt { get; set; }
        public string Country { get; set; }

    }

}
