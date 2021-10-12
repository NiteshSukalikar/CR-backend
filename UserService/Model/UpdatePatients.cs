using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UserService.ViewModel;

namespace UserService.Model
{
    public class UpdatePatients
    {
        public long UserId { get; set; }

        public long PatientId { get; set; }
        public int? TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int? BirthCountryId { get; set; }
        public int? BirthStateId { get; set; }
        public int? BirthCityId { get; set; }
        public string BirthAddress { get; set; }

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

        public int? MaritalStatusId { get; set; }
        public decimal? Height { get; set; }
        public string Disability { get; set; }
        public string NativeSpokenLanguage { get; set; }

        public int? ResidenceCountryId { get; set; }
        public int? ResidenceStateId { get; set; }
        public int? ResidenceCityId { get; set; }
        public string ResidenceAddress { get; set; }
        public string PostalCode { get; set; }

        public long? CreatedBy { get; set; }
        public long? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public long? ModifiedOn { get; set; }

        public bool IsActive { get; set; }
        public string ResponseResult { get; set; }

        public OrganizationVM organization { get; set; }
        public List<DelegationVM> delegationList { get; set; }
        public List<TagPatientDetails> tagPatientDetails { get; set; }
    }
}

