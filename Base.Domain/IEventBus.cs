
namespace Base.Domain
{
    public interface IEventBus
    {
        void Trigger<TEvent>(TEvent @event) 
            where TEvent : Event;

        void AttachHandler<TEvent, TEventHandler>(TEvent @event, TEventHandler eventHandler)
            where TEvent : Event
            where TEventHandler : IEventHandler;
    }
}