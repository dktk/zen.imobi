using System;

namespace Base.Domain
{
    public abstract class Event
    {
        public DateTime Date { get; set; }
        public long UserId { get; set; }
    }
}