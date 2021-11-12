namespace UserService.Model
{    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Numerics;
    using System.Runtime.Serialization;
    using UserService.ViewModel;

    public class UserDetailsModel
    {
        //Admin
        public long UserID { get; set; }
        public string MacAddress { get; set; }
        public string TransactionCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        //Admin Profile
        public long UserProfileID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string OtherName { get; set; }
        public int GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int CreatedByLoginID { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string EmailAddress { get; set; }
        public string? NativeSpokenLanguage { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
      

        //Organization

        public long OrganizationsID { get; set; }
        public string OrganizationsName { get; set; }
        public string BusinessName { get; set; }
        public string SubDomainName { get; set; }
        public string LogoName { get; set; }
        public string FaviconName { get; set; }
        public string Address { get; set; }
        public string EmailAddressOrg { get; set; }
        public string PrimaryContactNumberOrg { get; set; }
        public string SecondaryContactNumberOrg { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public long OrganizationTypesId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }


}
