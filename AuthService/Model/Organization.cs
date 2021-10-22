using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AuthService.Model
{
    [DataContract]
    public class Organization
    {
        [Required]
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        public string OrganizationName { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int? CountryID { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
        public bool IsActive { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ApartmentNumber { get; set; }
    }
}
