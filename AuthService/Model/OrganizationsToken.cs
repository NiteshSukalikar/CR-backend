using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class OrganizationsToken
    {
        public string? OrganizationEncryptString { get; set; }
        public string? OrganizationDecryptString { get; set; }
        public string? TokenType { get; set; }
        public string? TokenDescription { get; set; }
        
    }
}
