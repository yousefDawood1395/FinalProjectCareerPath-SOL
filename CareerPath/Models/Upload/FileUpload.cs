using CareerPath.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerPath.Models.Upload
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
