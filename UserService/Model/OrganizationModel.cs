using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class OrganizationModel
    {
        public long OrganizationsID { get; set; }
        public string OrganizationsName { get; set; }
        public string BusinessName { get; set; }
        public string SubDomainName { get; set; }
        public string LogoName { get; set; }
        public string FaviconName { get; set; }
        public long UserID { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
        public int StateID { get; set; }
        public int  CountryID { get; set; }
        public long OrganizationTypesId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
