using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class AdminInviteModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        //vendors details

        public string vendorFirstName { get; set; }
        public string vendorMiddleName { get; set; }
        public string vendorLastName { get; set; }
        public string vendorEmail { get; set; }
        public string vendorPrimaryContactNumber { get; set; }
        public string vendorSecondaryContactNumber { get; set; }
        public string subscription { get; set; }
    }
}
