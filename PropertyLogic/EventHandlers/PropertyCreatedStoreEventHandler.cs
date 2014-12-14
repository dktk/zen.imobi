using PropertyLogic.Events;

namespace Base.Domain.EventHandlers
{
    public class PropertyCreatedStoreEventHandler : StoreEventHandler<PropertyCreated>
    {
        public PropertyCreatedStoreEventHandler(EventsContext context)
            : base(context) { }
    }
    
    public class PropertyRentedStoreEventHandler : StoreEventHandler<PropertyRented> 
    {
        public PropertyRentedStoreEventHandler(EventsContext context)
            : base(context) { }
    }
}