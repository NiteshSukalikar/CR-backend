using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class OrganizationVM
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public int? ProviderType { get; set; }
        public string OrganizationName { get; set; }
        public string BusinessName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int Zip { get; set; }
        public string Description { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Fax { get; set; }

        public string ApartmentNumber { get; set; }
        public string Logo { get; set; }

        public string PhotoBase64 { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        //public string Favicon { get; set; }
        //public string ContactPersonFirstName { get; set; }
        //public string ContactPersonMiddleName { get; set; }
        //public string ContactPersonLastName { get; set; }
        //public string ContactPersonPhoneNumber { get; set; }
        //public int ContactPersonMa { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //  public int DatabaseDetailId { get; set; }
        //public int VendorIdDirect { get; set; }
        //public string VendorIdIndirect { get; set; }
        //public string VendorNameDirect { get; set; }
        //public string VendorNameIndirect { get; set; }
    }

    public class UploadDocumentsVM
    {
        public IFormFile UploadedImage { get; set; }
    }
}
