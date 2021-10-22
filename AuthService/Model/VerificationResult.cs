using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class VerificationResult
    {
        public VerificationResult(string sid,string response) 
        {
            Sid = sid;
            Response = response;
            IsValid = true;
        }

        public VerificationResult(List<string> errors)
        {
            Errors = errors;
            IsValid = false;
        }

        public string Sid { get; set; }

        public string Response { get; set; }

        public bool IsValid { get; set; }

        public List<string> Errors { get; set; }
    }
}
