using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Model
{
    public class TermiiResponseModel
    {
        public string ? pinId { get; set; }
        public string ? message { get; set; }
        public string ? to { get; set; }
        public string ? smsStatus { get; set; }
        public string ? status { get; set; }
        public string ? verified { get; set; }

    }


}
