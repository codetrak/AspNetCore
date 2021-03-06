﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Domain.Entities
{
    [Table("CatalogArtwork", Schema = "Artist")]
    public class CatalogArtwork
    {
        [Key]
        public int CatalogID { get; set; }
        public byte[] ArtWork { get; set; }
        public string OriginalName { get; set; }
        public string AssignedName { get; set; }
        public string Extension { get; set; }
        public Catalog Catalog { get; set; }
    }
}
