using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class PatientDocument
    {
        public string Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Type { get; set; }
        public string File { get; set; }
        public string PatientId { get; set; }
        public string FileExtension { get; set; }

        public List<FileList> FileList { get; set; }
    }
}
