using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string?  RoleId { get; set; }
        public bool? IsLab { get; set; } = false;
        public string otpVia { get; set; }
        public string? ipAddress { get; set; }
        public string? Country { get; set; }
        public string? LoginAttempt { get; set; }
        public int? OrganizationId { get; set; }
    }
    public class ActivationModel
    {
        public string activationCode { get; set; }
        //public long ssn { get; set; }
        //public DateTime dob { get; set; }
        public string dob { get; set; }
        public string userid { get; set; }
        public string mrn { get; set; }
    }
}
