using Base.Domain;
using Base.Domain.EventHandlers;
using Ninject;
using PropertyLogic.EventHandlers;
using PropertyLogic.Events;

namespace Zen.Imobi.Web
{
    public class BusMappings
    {
        private static IEventBus _eventBus;
        private static object sync = new object();

        public static void Configure(IKernel kernel)
        {
            if (_eventBus == null)
            {
                lock (sync)
                {
                    if (_eventBus == null)
                    {
                        _eventBus = kernel.Get<IEventBus>();
                    }
                }
            }

            // todo: remove the storeEventHandler and call it dynamically from the bus
            // todo: add a config strategy to enable/disable the handlers
            // todo: create a Dashboard for the configs

            // Property Created
            _eventBus.Register<PropertyCreated, PropertyCreatedStoreEventHandler>();

            // Property Rented
            _eventBus.Register<PropertyRented, SendPropertyRentedEmailHandler>();
            _eventBus.Register<PropertyRented, PropertyRentedStoreEventHandler>();
        }
    }
}