using Base;
using Ninject;
using Ninject.Syntax;
using PropertyLogic.Events;
using Rebus.Configuration;
using Rebus.Log4Net;
using Rebus.Ninject;
using Rebus.Transports.Msmq;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

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

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Guard.AgainstNullOrEmpty(resolver);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = this.resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.GetAll(serviceType);
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope,
                                            System.Web.Mvc.IDependencyResolver,
                                            IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}