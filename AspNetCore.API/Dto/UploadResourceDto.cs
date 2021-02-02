using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.Dto
{
    public class UploadResourceDto
    {
        public string CatalogName { get; set; }
        public IFormFile UploadedFile { get; set; }
        public int ArtistID { get; set; }
        public string Description { get; set; }
        public int CatalogTypeID { get; set; }
        public string Name { get; set; }
        public string AssignedName { get; set; }
        public string Extension { get; set; }
        public byte[] DataFile { get; set; }
        public string ErrorMessage { get; set; }

    }
}
