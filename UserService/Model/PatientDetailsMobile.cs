﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class PatientDetailsMobile
    {
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ResidenceCountryId { get; set; }
        public int ResidenceStateId { get; set; }
        public int ResidenceCityId { get; set; }
        public string ResidenceAddress { get; set; }

        public string dob { get; set; }
        public Int16? GenderId { get; set; }
        public string nin { get; set; }
        public string bvn { get; set; }
        public string Passport { get; set; }

        [Required]
        [DataMember(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required]
        [DataMember(Name = "EmailAddress")]
        public string EmailAddress { get; set; }

        public string NextOfKinsName { get; set; }
        public string NextOfKinsRelationship { get; set; }
        public string NextOfKinsTelephone { get; set; }
        public int? NextOfKinsCountryId { get; set; }
        public int? NextOfKinsStateId { get; set; }
        public int? NextOfKinsCityId { get; set; }
        public string NextOfKinsAddress { get; set; }
    }

    public class ResponsePatientMobile
    {
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string MRN { get; set; }
        public string ActivationCode { get; set; }
        public string StatusCode { get; set; }
    }
}