namespace AuthService.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="UserDetails" />
    /// </summary>
    [DataContract]
    public class UserDetails 
    {
        public string Id { get; set; }
        public long UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool Active { get; set; }
        public bool isActivated { get; set; }
        public string  ActivationCode{ get; set; }
        public long SSN { get; set; }
        public DateTime? Dob{ get; set; }
        public string DobEncrypted { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string Mrn { get; set; }
        public string ContactNumber { get; set; }
        public byte[]? _contactNumber { get; set; }
        public int RoleId { get; set; }
        public int? UserType { get; set; }
        public bool OTPRequired { get; set; }
        public string ResponseResult { get; set; }
        public int? OrganizationId { get; set; }
    }
}
