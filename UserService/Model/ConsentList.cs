using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class PatientConcent
    {
        public int Id { get; set; }

        public long PatientId { get; set; }
        public string MRN { get; set; }

        public int OrganizationId { get; set; }

        public string ConcentStatus { get; set; }
        public string PatientName { get; set; }
        public string RequestedBy { get; set; }
        public string OrganizationName { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public long? TotalRecords { get; set; }
        public bool isRequest { get; set; }

    }
}
