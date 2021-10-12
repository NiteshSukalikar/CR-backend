using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class UserProfile
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set;}
        public string ResponseResult { get; set; }
        public long ModifiedBy { get; set; }
        public long ModifiedOn { get; set; }

       
    }
}
