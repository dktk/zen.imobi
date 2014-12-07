using Base;
using Ninject;
using PropertyLogic.Events;
using Rebus;
using Rebus.Configuration;
using Rebus.Log4Net;
using Rebus.Ninject;
using Rebus.Transports.Msmq;

namespace Zen.Imobi.Web
{
    public class RebusConfig
    {
        public static void Start(IKernel kernel)
        {
            Guard.AgainstNullOrEmpty(kernel);

            var adapter = new NinjectContainerAdapter(kernel);

            var bus = Configure
                        .With(adapter)
                        .Logging(log => log.Use(new Log4NetLoggerFactory()))
                        .MessageOwnership(d => d.FromRebusConfigurationSection())

                        // todo: while in dev, this uses MSMQ
                        // when deploying, this should be changed to the Azure Stuff
                        .Transport(transport => transport.UseMsmqAndGetInputQueueNameFromAppConfig())
                        
                        .Subscriptions(subscription => subscription.StoreInSqlServer(Config.ConnectionString, Config.RebusSubscriptionTableName).EnsureTableIsCreated())
                        .Sagas(saga => saga.StoreInSqlServer(Config.ConnectionString, Config.RebusSagaTable, Config.RebusSagaIndexTable).EnsureTablesAreCreated())
                        .CreateBus()
                        .Start();

            bus.Subscribe<PropertyCreated>();
        }
    }

    public class ImportantThingHappenedHandler : IHandleMessages<PropertyCreated>
    {
        public void Handle(PropertyCreated message)
        {
           
        }
    }
}