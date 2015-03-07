using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;
using Albatross.Example.Domain;
using Albatross.Example.Services.Interfaces;
using Albatross.Example.Services.Services;
using Albatross.Repositories;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;
using System.Linq;

namespace Albatross.Example.API.Config
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
            container.RegisterType<IRepository<ToDo>, EntityFrameworkRepository<ToDo>>(new TransientLifetimeManager());
            container.RegisterType<IToDoService, ToDoService>(new TransientLifetimeManager());
            container.RegisterType<ToDoHub, ToDoHub>(new ContainerControlledLifetimeManager());
            container.RegisterType<IHubActivator, UnityHubActivator>(new ContainerControlledLifetimeManager());
        }

    }
}
