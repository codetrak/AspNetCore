using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("ArtistDescription", Schema = "Artist")]
    public class ArtistDescription
    {
        [Key]
        public int ArtistID { get; set; }
        public string Description { get; set; }
        public Artist Artist { get; set; }
    }
}
