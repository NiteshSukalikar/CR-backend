using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class UsersTemplate
    {
        [Required]
        [DataMember(Name = "Id")]
        public long Id { get; set; }

        public int InvestigationCenterId { get; set; }
    }
}
