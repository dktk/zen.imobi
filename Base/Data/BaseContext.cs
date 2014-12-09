using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Base.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext()
            : this("DefaultConnection")
        {

        }

        public BaseContext(DbConnection connection)
            : base(connection, true)
        {
            Database.Initialize(true);    
        }

        public BaseContext(string connectionString) : base(connectionString) { }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
