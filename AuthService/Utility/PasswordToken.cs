using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Utility
{
    public class PasswordToken
    {
        public Guid ForgotPasswordRequestGuid { get; set; }
        public string ForgotPasswordRequestToken { get; set; }
        public int UserID { get; set; }
        public DateTime ForgotPasswordRequestExpiration { get; set; }
        public int ForgotPasswordRequestStatus { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime ForgotPasswordRequestedOn { get; set; }
    }
}
