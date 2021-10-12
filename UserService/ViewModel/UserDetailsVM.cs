using IEH_Users.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UserService.Model;

namespace UserService.ViewModel
{
    public class UserDetailsVM
    {
        public int UserType { get; set; }
        public int? ProviderType { get; set; }
        public int? RoleId { get; set; }
        public int? OrgId { get; set; }
        public long? UserId { get; set; }


        public long Id { get; set; }
        public int? TitleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string OtherName { get; set; }

        public int? ResidenceCountryId { get; set; }
        public int? ResidenceStateId { get; set; }
        public int? ResidenceCityId { get; set; }
        public string ResidenceAddress { get; set; }

        public string dob { get; set; }
        public Int16? GenderId { get; set; }
        public string nin { get; set; }
        public string bvn { get; set; }
        public string Passport { get; set; }
        public string License { get; set; }

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

        public string PostalCode { get; set; }
        public string NativeSpokenLanguage { get; set; }
        public string Nationality { get; set; }

        public string OtherSpokenLanguage { get; set; }
        public string ReadWriteLanguage { get; set; }

        public string EducationLevel { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }


        public bool IsActive { get; set; }
        public string ResponseResult { get; set; }

        public long? CreatedBy { get; set; }
        public long? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public long? ModifiedOn { get; set; }
        public string MRN { get; set; }
        public string FullName { get; set; }


        public OrganizationVM organization { get; set; }
        public int? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActivated { get; set; }

        public string Gender { get; set; }

        public string TitleName { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoBase64 { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? Amount { get; set; }
        public long? TotalRecords { get; set; }
        public int? OrgIdForConsent { get; set; }

        public string MaritalStatus { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public List<DelegationVM> delegationList { get; set; }
        public List<TagPatientDetails> tagPatientDetails { get; set; }
    }
}
