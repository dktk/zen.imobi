namespace Base.Domain
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) 
            where TEvent : Event;
    }
}