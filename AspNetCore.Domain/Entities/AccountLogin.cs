using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("AccountLogin", Schema = "Person")]
    public class AccountLogin
    {
        [Key]
        public int EntityID { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public Person Person { get; set; }

        [NotMapped]
        public string Password { get; set; }
        
        [NotMapped]
        public string PasswordConfirm { get; set; }        
        public AccountRole AccountRole { get; set; }
    }
}