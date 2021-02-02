using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Domain.Entities
{
    [Table("Catalog", Schema = "Artist")]
    public class Catalog
    {
        [Key]
        public int CatalogID { get; set; }
        public int CatalogTypeID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public CatalogDescription CatalogDescription { get; set; }
        public CatalogArtwork CatalogArtwork { get; set; }
        public CatalogType CatalogType { get; set; }

    }
}
