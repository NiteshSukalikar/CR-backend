using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{
    public class PatientDetailsMobVM
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string LastName { get; set; }

        public string ResidenceCountry { get; set; }
        public string ResidenceState { get; set; }
        public string ResidenceCity { get; set; }
        public string ResidenceAddress { get; set; }

        public string dob { get; set; }
        public string Gender { get; set; }
        public string nin { get; set; }
        public string bvn { get; set; }
        public string Passport { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public string NextOfKinsName { get; set; }
        public string NextOfKinsRelationship { get; set; }
        public string NextOfKinsTelephone { get; set; }
        public string NextOfKinsCountry { get; set; }
        public string NextOfKinsState { get; set; }
        public string NextOfKinsCity { get; set; }
        public string NextOfKinsAddress { get; set; }
    }
}
