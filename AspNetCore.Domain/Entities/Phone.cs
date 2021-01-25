using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("Phone", Schema = "Person")]
    public class Phone
    {
        [Key]
        public int EntityID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public Person Person { get; set; }
    }
}