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
    public class PatientDetails
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        public long Id { get; set; }
        public int OrgId { get; set; }

        /// <summary>
        /// Gets or sets the RoleId
        /// </summary>
        [DataMember(Name = "RoleId")]
        public long RoleId { get; set; }


        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "UserId")]
        public long? UserId { get; set; }
        public long TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>

        [DataMember(Name = "TitleId")]
        public int TitleId { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [Required]
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Required]
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the MiddleName
        /// </summary>
        [DataMember(Name = "MiddleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the MaidenName
        /// </summary>

        [DataMember(Name = "MaidenName")]
        public string MaidenName { get; set; }

        /// <summary>
        /// Gets or sets the OtherName
        /// </summary>

        [DataMember(Name = "OtherName")]
        public string OtherName { get; set; }


        /// <summary>
        /// Gets or sets the NIMC
        /// </summary>
        [DataMember(Name = "NIMC")]
        public int NIMC { get; set; }

        /// <summary>
        /// Gets or sets the DOB
        /// </summary>
        [DataMember(Name = "DOB")]
        public string DOB { get; set; }


        /// <summary>
        /// Gets or sets the BirthdateVerify
        /// </summary>
        [DataMember(Name = "BirthdateVerify")]
        public Boolean BirthdateVerify { get; set; }

        /// <summary>
        /// Gets or sets the BirthCountry
        /// </summary>
        [DataMember(Name = "BirthCountryId")]
        public int? BirthCountryId { get; set; }

        /// <summary>
        /// Gets or sets the PlaceOfBirth
        /// </summary>


        [DataMember(Name = "PlaceOfBirthId")]
        public int? PlaceOfBirthId { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        [DataMember(Name = "GenderId")]
        public int GenderId { get; set; }

        /// <summary>
        /// Gets or sets the MaritalStatus
        /// </summary>
        [Required]
        [DataMember(Name = "MaritalStatusId")]
        public int MaritalStatusId { get; set; }

        /// <summary>
        /// Gets or sets the MaritalStatus
        /// </summary>
        [DataMember(Name = "Age")]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the Height
        /// </summary>
        [DataMember(Name = "Height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the ResidenceStatus 
        /// </summary>
        [DataMember(Name = "ResidenceStatus ")]
        public string ResidenceStatus { get; set; }

        /// <summary>
        /// Gets or sets the NativeSpokenLanguage
        /// </summary>
        [DataMember(Name = "NativeSpokenLanguage")]
        public string NativeSpokenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the OtherSpokenLanguage
        /// </summary>
        [DataMember(Name = "OtherSpokenLanguage")]
        public string OtherSpokenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the ReadWriteLanguage 
        /// </summary>
        [DataMember(Name = "ReadWriteLanguage ")]
        public string ReadWriteLanguage { get; set; }

        /// <summary>
        /// Gets or sets the EducationLevel 
        /// </summary>
        [DataMember(Name = "EducationLevel ")]
        public string EducationLevel { get; set; }

        /// <summary>
        /// Gets or sets the Profession 
        /// </summary>
        [DataMember(Name = "Profession ")]
        public string Profession { get; set; }

        /// <summary>
        /// Gets or sets the EmploymentStatus  
        /// </summary>
        [DataMember(Name = "EmploymentStatus  ")]
        public string EmploymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the Disability  
        /// </summary>
        [DataMember(Name = "Disability  ")]
        public string Disability { get; set; }

        /// <summary>
        /// Gets or sets the PlaceOfOrigin  
        /// </summary>

        [DataMember(Name = "PlaceOfOriginId  ")]
        public int? PlaceOfOriginId { get; set; }

        /// <summary>
        /// Gets or sets the CountryOfResidence  
        /// </summary>
        [DataMember(Name = "CountryOfResidenceId  ")]
        public int? CountryOfResidenceId { get; set; }

        /// <summary>
        /// Gets or sets the PlaceOfResidence  
        /// </summary>
        [DataMember(Name = "PlaceOfResidenceId  ")]
        public int? PlaceOfResidenceId { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode  
        /// </summary>
        [DataMember(Name = "PostalCode  ")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode  
        /// </summary>
        [DataMember(Name = "Address  ")]
        public string Address { get; set; }

        [Required]
        [DataMember(Name = "EmailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        [DataMember(Name = "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [DataMember(Name = "Password")]
        public string Password { get; set; }


        [DataMember(Name = "RoleName")]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the ContactNumber
        /// </summary>
        [Required]
        [DataMember(Name = "Telephone")]
        public string Telephone { get; set; }
        /// <summary>
        /// Gets or sets the NextOfKinsName  
        /// </summary>

        [DataMember(Name = "NextOfKinsName  ")]
        public string NextOfKinsName { get; set; }

        /// <summary>
        /// Gets or sets the NextOfKinsAddress  
        /// </summary>

        [DataMember(Name = "NextOfKinsAddress  ")]
        public string NextOfKinsAddress { get; set; }

        /// <summary>
        /// Gets or sets the NextOfKinsRelationship
        /// </summary>
        public string NextOfKinsRelationship { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the ResponseResult
        /// </summary>
        public string ResponseResult { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreayedOn
        /// </summary>
        [DataMember(Name = "CreatedOn")]
        public long CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy
        /// </summary>
        [DataMember(Name = "ModifiedBy")]
        public long ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn
        /// </summary>
        [DataMember(Name = "ModifiedOn")]
        public long ModifiedOn { get; set; }
        public String MRN { get; set; }
        public String FullName { get; set; }
        public OrganizationVM organization { get; set; }
        public int? OrganizationId { get; set; }
        public long SSN { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActivated { get; set; }
        public int Usertype { get; set; }

        public string Gender { get; set; }

        public string StatusName { get; set; }

        public string TitleName { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoBase64 { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Amount { get; set; }
        //public long TotalRecords { get; set; }
        public int? OrgIdForConsent { get; set; }

        public string MaritalStatus { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }

        public string Temperature { get; set; }
        public string HeartRate { get; set; }
        public string BloodPressureSystolic { get; set; }
        public string BloodPressureDiastolic { get; set; }
        public string Respiration { get; set; }
        public string O2Saturation { get; set; }
      
        public int Weight { get; set; }
        public long PatientId { get; set; }
    }
}
