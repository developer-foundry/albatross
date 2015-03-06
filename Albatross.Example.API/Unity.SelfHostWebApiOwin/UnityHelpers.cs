using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;
using System.Linq;
using SignalRSelfHost;
using SignalR_Rx_SelfHost_Domain;
using SignalR_Rx_SelfHost_Example;
using SignalR_Rx_SelfHost_Example.Unity.SelfHostWebApiOwin;
using SignalR_Rx_SelfHost_Repository;
using SignalR_Rx_SelfHost_Services;

namespace Unity.SelfHostWebApiOwin
{
    public static class UnityHelpers
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(Startup));
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager()); 
            container.RegisterType<IRepository, EntityFrameworkRepository>(new TransientLifetimeManager());
            container.RegisterType<IObservableRepository<Stock>, EntityFrameworkObservableRepository<Stock>>(new TransientLifetimeManager());
            container.RegisterType<ITickerService, TickerService>(new TransientLifetimeManager());
            container.RegisterType<MyHub, MyHub>(new ContainerControlledLifetimeManager());
            container.RegisterType<IHubActivator, UnityHubActivator>(new ContainerControlledLifetimeManager());
        }

    }
}
