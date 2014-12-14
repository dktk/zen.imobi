using Base.Domain.EventHandlers;
using PropertyLogic.Events;

namespace PropertyLogic.EventHandlers
{
    public class SendPropertyRentedEmailHandler : StoreEventHandler<PropertyRented>
    {
        public SendPropertyRentedEmailHandler(EventsContext context)
            : base(context)
        {
            // todo:
        }
    }
}
