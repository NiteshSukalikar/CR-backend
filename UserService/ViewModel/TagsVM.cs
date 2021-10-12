using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.ViewModel
{

    public class TagsVM
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchText { get; set; }

        public long TotalRecords { get; set; }

        public int Id { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }

    }

    public class TagPatientDetails
    {
        public long PatientId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
