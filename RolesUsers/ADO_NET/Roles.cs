using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RolesUsers.ADO_NET
{
    [Table("Roles")]
    public class Roles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] public int ID { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public virtual ICollection<Users> Users { get; set; } = new HashSet<Users>();
    }
}
