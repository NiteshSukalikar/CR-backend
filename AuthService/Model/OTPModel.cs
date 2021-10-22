using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class OTPModel
    { 
        public string? UserId { get; set; }
        public string OTP { get; set; }
        public int? OrganizationId { get; set; }
        public int? RoleId { get; set; }
        public string? DeviceToken { get; set; }
        public string otpVia { get; set; }
        public string? ipAddr { get; set; }
        public string? Country { get; set; }
        public string? LoginAttempt { get; set; }
        public string? PinId  { get; set; }
        public bool? IsDelgationUserLogin { get; set; } = false;
    }

    public class ForgotPassword
    {
        public string Email { get; set; }
        public string otpVia { get; set; }
        public int RoleId { get; set; }

    }
    public class ResetPassword
    {
        public string Password { get; set; }
        public string UserId { get; set; }
        public string ResponseResult { get; set; }
    }

    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
