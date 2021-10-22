using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class MemberTypeAndCompanyDetails
    {
        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "CompanyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        [DataMember(Name = "MemberTypeId")]
        public long MemberTypeId { get; set; }
    }
}
