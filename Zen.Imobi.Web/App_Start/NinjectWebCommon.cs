[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Zen.Imobi.Web.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Zen.Imobi.Web.NinjectWebCommon), "Stop")]

namespace Zen.Imobi.Web
{
    using Base;
    using Base.Domain;
    using Base.Time;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using PropertyLogic.Data;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel Kernel
        {
            get;
            private set;
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            
            Kernel = CreateKernel();

            bootstrapper.Initialize(() => Kernel);            
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
      
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPropertiesRepository>().To<PropertiesRepository>();
            kernel.Bind<PropertyLogic.Property>().To<PropertyLogic.Property>();

            kernel.Bind<IIdentityProvider>().To<IdentityProvider>();
            kernel.Bind<ITimeResolver>().To<TimeResolver>();
            
            kernel.Bind<IEventBus>().To<EventBus>();
        }        
    }
}