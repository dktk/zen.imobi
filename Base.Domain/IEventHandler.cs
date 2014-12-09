namespace Base.Domain
{
    public interface IEventHandler<TEvent>
        where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}