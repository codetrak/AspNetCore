using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Domain.Entities
{
    [Table("AccountRole", Schema = "Person")]
    public class AccountRole
    {
        [Key]
        public int RoleID { get; set; }
        public int RoleTypeID { get; set; } 
        public int RoleStatusID { get; set; } 
        public int EntityID { get; set; }
        public DateTime BeginDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public AccountLogin AccountLogin { get; set; }
        public AccountRoleType AccountRoleType { get; set; }
        public AccountRoleStatus AccountRoleStatus { get; set; }

    }
}