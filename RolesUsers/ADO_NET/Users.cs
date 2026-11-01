using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolesUsers.ADO_NET
{
    [Table("Users")]
    public class Users
    {
        [Key] public int ID { get; set; }
        [StringLength(50)] public string Login { get; set; }
        [StringLength(50)] public string Password { get; set; }
        [StringLength(50)] public string First_Name { get; set; }
        [StringLength(50)] public string Second_Name { get; set; }
        public string Pictures { get; set; }
        public int? RoleID { get; set; }
        [ForeignKey("RoleID")] public virtual Roles Role { get; set; }
    }
}
