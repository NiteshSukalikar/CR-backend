using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class UserProfileVM
    {
        public long? UserId { get; set; }

        public long Id { get; set; }
        public int? TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? ResidenceCountryId { get; set; }
        public int? ResidenceStateId { get; set; }
        public int? ResidenceCityId { get; set; }
        public string ResidenceAddress { get; set; }

        public string dob { get; set; }
        public Int16? GenderId { get; set; }

        public string Telephone { get; set; }

        public string EmailAddress { get; set; }

        public string PostalCode { get; set; }
    }
}
