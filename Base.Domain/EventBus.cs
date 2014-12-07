using Rebus;

namespace Base.Domain
{
    public class EventBus : IEventBus
    {
        private readonly IBus _bus;

        public EventBus(IBus bus)
        {
            Guard.AgainstNullOrEmpty(bus);

            _bus = bus;
        }

        public void Publish<TEvent>(TEvent @event)
            where TEvent : Event
        {
            Guard.AgainstNullOrEmpty(@event);

            _bus.Publish(@event);            
        }
    }
}