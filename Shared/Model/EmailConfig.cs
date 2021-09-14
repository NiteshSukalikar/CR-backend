using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    public class EmailConfig
    {
        public String FromName { get; set; }
        public String FromAddress { get; set; }

        public String LocalDomain { get; set; }

        public String MailServerAddress { get; set; }
        public String MailServerPort { get; set; }

        public String UserId { get; set; }
        public String UserPassword { get; set; }
    }

    public class EmailSettings
    {
        public string Email { get; set; }
        public string FromName { get; set; }
        public string MailServerAddress { get; set; }
        public string UserPasswordSmtp { get; set; }
        public string UserPasswordV3 { get; set; }
        public string MailServerPort { get; set; }
        public string UserId { get; set; }
    }

}
