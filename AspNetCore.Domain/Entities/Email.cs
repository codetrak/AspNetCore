using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("Email", Schema = "Person")]
    public class Email
    {
        [Key]
        public int EntityID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public Person Person { get; set; }
    }
}