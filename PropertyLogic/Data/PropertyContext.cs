using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PropertyLogic.Data
{
    public class PropertyContext : DbContext
    {
        public virtual DbSet<PropertyDao> Properties { get; set; }
        public virtual DbSet<LocationDao> Locations { get; set; }

        public PropertyContext()
            : this("DefaultConnection")
        {

        }

        public PropertyContext(DbConnection connection)
            : base(connection, true)
        {
            Database.Initialize(true);    
        }

        public PropertyContext(string connectionString) : base(connectionString) { }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}