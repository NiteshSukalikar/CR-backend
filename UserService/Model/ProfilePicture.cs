using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class ProfilePicture
    {
        public long UserId { get; set; }
        public List<FileList> FileList { get; set; }
    }

    public class FileList
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileType { get; set; }
    }

    public class OrganizationLogo
    {
        public long OrganizationId { get; set; }
        public List<FileList> FileList { get; set; }
    }
}
