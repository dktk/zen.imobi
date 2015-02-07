using System.Data.Entity;

namespace Base.Domain.EventHandlers
{
    public class StoreEventHandler<TEvent> : IEventHandler<TEvent>
        where TEvent : Event
    {
        private readonly DbContext _context;

        public StoreEventHandler(DbContext context)
        {
            _context = context;
        }

        public void Handle(TEvent @event)
        {
            _context.Set<TEvent>().Add(@event);
            
            /// todo: savechangesAsync???
            _context.SaveChanges();
        }
    }
}
