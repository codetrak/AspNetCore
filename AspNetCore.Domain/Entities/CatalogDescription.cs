using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Domain.Entities
{
    [Table("CatalogDescription", Schema = "Artist")]
    public class CatalogDescription
    {
        [Key]
        public int CatalogID { get; set; }
        public string Description { get; set; }
        public Catalog Catalog { get; set; }

    }
}
