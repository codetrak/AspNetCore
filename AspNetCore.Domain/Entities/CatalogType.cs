using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Domain.Entities
{
    [Table("CatalogType", Schema = "Artist")]
    public class CatalogType
    {
        public CatalogType()
        {
            Catalogs = new HashSet<Catalog>();
        }

        [Key]
        public int CatalogTypeID { get; set; }
        public string CatalogTypeName { get; set; }
        public ICollection<Catalog> Catalogs { get; set; }
    }
}
