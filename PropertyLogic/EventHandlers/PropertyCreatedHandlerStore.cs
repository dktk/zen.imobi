using Base.Domain.EventHandlers;
using PropertyLogic.Events;

namespace PropertyLogic.EventHandlers
{
    public class PropertyCreatedHandlerStore : StoreEventHandler<PropertyCreated>
    {
        public PropertyCreatedHandlerStore(EventsContext context)
            : base(context)
        {

        }
    }
}
