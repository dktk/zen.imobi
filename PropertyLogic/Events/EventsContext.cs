using Base.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PropertyLogic.Events
{
    public class EventsContext : BaseContext
    {
        // todo: this needs to map to table events.PropertyCreated
        public virtual DbSet<PropertyCreated> PropertyCreated { get; set; }
    }
}