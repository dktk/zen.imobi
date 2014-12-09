using Base.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PropertyLogic.Data
{
    public class PropertyContext : BaseContext
    {
        public virtual DbSet<PropertyDao> Properties { get; set; }
        public virtual DbSet<LocationDao> Locations { get; set; }
    }
}