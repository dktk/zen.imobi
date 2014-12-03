using System;

namespace Base.Domain
{
    public abstract class Event
    {
        public DateTime Date { get; private set; }
        public Guid UserId { get; private set; }

        public Event(Guid userId)
        {
            Guard.AgainstNullOrEmpty(userId);

            UserId = userId;

            // todo: use TimeResolver
            Date = DateTime.Now;
        }
    }
}