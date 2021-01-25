using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("Person", Schema = "Person")]
    public class Person
    {
        [Key]
        public int EntityID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Foreign Key References
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Location Location { get; set; }
    }
}