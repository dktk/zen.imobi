using Base;
using Base.Domain;
using Rebus;
using System;

namespace PropertyLogic.Events
{
    public class PropertyCreated : Event
    {
        public Guid PropertyId { get; private set; }

        public PropertyCreated(Guid userId, Guid propertyId)
            : base(userId)
        {
            Guard.AgainstNullOrEmpty(propertyId);

            PropertyId = propertyId;
        }
    }
}