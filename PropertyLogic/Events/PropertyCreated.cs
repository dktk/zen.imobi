using Base.Domain;

namespace PropertyLogic.Events
{
    public class PropertyCreated : Event
    {
        public long PropertyId { get; private set; }

        public PropertyCreated(long propertyId)
        {
            PropertyId = propertyId;
        }
    }
}