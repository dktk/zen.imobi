using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain
{
    public class EventBus : IEventBus
    {
        private static Dictionary<Type, List<Type>> _mappings = new Dictionary<Type, List<Type>>();
        private static Type _listType = typeof(List<Type>);

        public void Trigger<TEvent>(TEvent @event)
            where TEvent : Event
        {
            Guard.AgainstNullOrEmpty(@event);

            var eventType = typeof(TEvent);
            var eventHandlers = new List<Type>();

            if (!_mappings.TryGetValue(eventType, out eventHandlers))
            {
                Guard.Throw<InvalidOperationException>("There is no handler configured for the {0} event.", eventType.FullName);
            }
        }

        public void AttachHandler<TEvent, TEventHandler>(TEvent @event, TEventHandler @eventHandler) 
            where TEvent : Event
            where TEventHandler : IEventHandler
        {
            Guard.AgainstNullOrEmpty(@event);
            Guard.AgainstNullOrEmpty(@eventHandler);

            var eventType = typeof(TEvent);
            var eventHandlers = new List<Type>();

            if (!_mappings.TryGetValue(eventType, out eventHandlers))
            {
                _mappings.Add(eventType, eventHandlers);
            }

            eventHandlers.Add(@eventHandler.GetType());
        }
    }
}