using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    public class TokenClaimsModal
    {
        public int UserId { get; set; }
        public int? OrganizationId { get; set; }
        public string EmailAddress { get; set; }
        public int RoleID { get; set; }
        public int? staffId { get; set; }
        public string timeZone { get; set; }
    }
}
