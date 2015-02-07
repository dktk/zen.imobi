using Base.Domain.EventHandlers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Domain
{
    public class EventBus : IEventBus
    {
        private readonly IKernel _kernel;

        private static readonly Dictionary<Type, List<Type>> _mappings = new Dictionary<Type, List<Type>>();
        
        public EventBus(IKernel kernel)
        {
            Guard.AgainstNullOrEmpty(kernel);

            _kernel = kernel;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            var eventType = typeof(TEvent);

            var eventHandlerTypes = _mappings.FirstOrDefault(map => map.Key == eventType).Value;

            eventHandlerTypes.Match<List<Type>, InvalidOperationException>(
                    _ => eventHandlerTypes.IsNullOrEmpty(),
                    "There is no event handler mapped to: " + eventType.FullName,
                    _ =>
                    {
                        foreach (var eventHandlerType in _)
                        {
                            TriggerEventHandler(eventHandlerType, @event);
                        }
                    }
                );
        }

        private void TriggerEventHandler<TEvent>(Type eventHandlerType, TEvent @event)
            where TEvent: Event
        {
            eventHandlerType.Match<Type, InvalidOperationException>(
                _ => _.IsNull(),
                "Can not resolve handler: " + eventHandlerType.FullName,
                _ =>
                {
                    var instance = _kernel.TryGet(_) as IEventHandler<TEvent>;

                    instance.Handle(@event);
                });
        }

        public void Register<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : class, IEventHandler<TEvent>
        {
            var eventType = typeof(TEvent);
            var eventHandlers = _mappings.GetOrAdd(eventType);

            if (eventHandlers == null)
            {
                eventHandlers = new List<Type>();

                _mappings[eventType] = eventHandlers;
            }

            eventHandlers.Add(typeof(TEventHandler));
        }
    }
}