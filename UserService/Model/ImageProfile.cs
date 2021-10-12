using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class ImageProfile
    {
        [DataMember(Name = "UserId")]
        public long UserId { get; set; }
        public string ResponseResult { get; set; }
        public string PhotoPath { get; set; }
        public string PhotoBase64 { get; set; }
    }
}
