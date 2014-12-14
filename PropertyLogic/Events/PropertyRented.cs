using System;

namespace PropertyLogic.Events
{
    public class PropertyRented : PropertyEvent
    {
        public PropertyRented(Guid userId, Guid propertyId)
            : base(userId, propertyId)
        {

        }
    }
}