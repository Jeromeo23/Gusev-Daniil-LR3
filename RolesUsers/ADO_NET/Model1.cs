using System.Data.Entity;

namespace RolesUsers.ADO_NET
{
    public class Model1 : DbContext
    {
        public Model1() : base("name=Model1") { }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
    }
}
