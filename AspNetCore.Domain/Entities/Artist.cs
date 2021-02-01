using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Domain.Entities
{
    [Table("Artist", Schema = "Artist")]
    public class Artist
    {
        public Artist()
        {
            Catalogs = new HashSet<Catalog>();
        }

        [Key]
        public int ArtistID { get; set; }
        public int EntityID { get; set; }
        public string Name { get; set; }
        public ArtistDescription ArtistDescription { get; set; }
        public Person Person { get; set; }
        public ICollection<Catalog> Catalogs { get; set; }
    }
}
