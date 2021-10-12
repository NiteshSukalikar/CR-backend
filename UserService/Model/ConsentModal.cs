using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class PatientConsentModal
    {
        public int Id { get; set; }
        public int ConsentStatusId { get; set; }
        public long PatientId { get; set; }
        public int OrganizationId { get; set; }
        public bool isRequest { get; set; }
    }
}
