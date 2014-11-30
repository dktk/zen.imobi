using System;

namespace Base.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public bool HideFromUI { get; set; }

        public void TriggerEvent<T>(T @event)
            where T: Event
        {
            throw new NotImplementedException();
        }
    }
}