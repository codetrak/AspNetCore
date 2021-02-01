using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("AccountRoleStatus", Schema = "Person")]
    public class AccountRoleStatus
    {
        [Key]
        public int RoleStatusID { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public AccountRole AccountRole { get; set; }
    }
}