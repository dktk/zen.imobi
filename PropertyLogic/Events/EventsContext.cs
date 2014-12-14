using Base.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PropertyLogic.Events
{
    public class EventsContext : BaseContext
    {
        public virtual DbSet<PropertyCreated> PropertyCreated { get; set; }
        public virtual DbSet<PropertyRented> PropertyRented { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PropertyCreated>().ToTable("events.PropertyCreated");
            modelBuilder.Entity<PropertyRented>().ToTable("events.PropertyRented");
        }
    }
}