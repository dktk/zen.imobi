namespace Base.Domain
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) 
            where TEvent : Event;

        void Register<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : class, IEventHandler<TEvent>;
    }
}