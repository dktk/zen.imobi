using Base;
using Base.Domain;
using System;

namespace PropertyLogic.Events
{
    public class PropertyEvent : Event
    {
        public Guid PropertyId { get; private set; }

        public PropertyEvent(Guid userId, Guid propertyId)
            : base(userId)
        {
            Guard.AgainstNullOrEmpty(propertyId);

            PropertyId = propertyId;
        }
    }
}