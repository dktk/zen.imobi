﻿using System;

namespace PropertyLogic.Events
{
    public class PropertyCreated : PropertyEvent
    {
        public PropertyCreated(Guid userId, Guid propertyId)
            : base(userId, propertyId)
        {
        }
    }
}