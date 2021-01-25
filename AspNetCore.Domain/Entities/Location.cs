using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("Location", Schema = "Person")]
    public class Location
    {
        [Key]
        public int EntityID { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public Person Person { get; set; }
    }
}