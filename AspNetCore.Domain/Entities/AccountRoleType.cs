using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("AccountRoleType", Schema = "Person")]
    public class AccountRoleType
    {
        [Key]
        public int RoleTypeID { get; set; }
        public string RoleName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public AccountRole AccountRole { get; set; }

    }
}