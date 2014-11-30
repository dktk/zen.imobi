using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PropertyLogic.Data
{
    public class PropertyContext : DbContext
    {
        public virtual ICollection<PropertyDao> Properties { get; set; }

        public PropertyContext()
        {

        }

        public PropertyContext(string connectionString) : base(connectionString) { }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}