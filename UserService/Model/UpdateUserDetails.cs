namespace UserService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="UpdateUserDetails" />
    /// </summary>
    public class UpdateUserDetails
    {
        public long Id { get; set; }
        public int? OrgId { get; set; }
        public int? UserType { get; set; }
        public int? ProviderType { get; set; }
        public int? RoleId { get; set; }
        public long? UserId { get; set; }

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
        public string License { get; set; }
        [Required]
        [DataMember(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required]
        [DataMember(Name = "EmailAddress")]
        public string EmailAddress { get; set; }


        public string PostalCode { get; set; }
        public string NativeSpokenLanguage { get; set; }
        public string OtherSpokenLanguage { get; set; }
        public string ReadWriteLanguage { get; set; }

        public string EducationLevel { get; set; }
        public string Profession { get; set; }
        public string EmploymentStatus { get; set; }

        public string ResponseResult { get; set; }
        public bool IsActive { get; set; }

        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public OrganizationVM organization { get; set; }
        public int? OrganizationId { get; set; }

    }
}
