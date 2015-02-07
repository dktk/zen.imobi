using System;

namespace PropertyLogic.Events
{
    public class PropertyOfferedForRent : PropertyEvent
    {
        public PropertyOfferedForRent(Guid userId, Guid propertyId)
            : base(userId, propertyId)
        {

        }
    }
}