using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class ProfileUpdate
    {
      
        public string PhotoPath { get; set; }
        public string FileExtension { get; set; }
        public IFormFile UploadedFile { get; set; }

        public long UserId { get; set; }

    }
}
