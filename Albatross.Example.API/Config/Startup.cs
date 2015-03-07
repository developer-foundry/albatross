using Albatross.Example.API;
using Albatross.Example.API.Config;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System;
using System.Linq;
using Microsoft.Practices.Unity;
using System.Web.Http.Filters;
using Unity.SelfHostWebApiOwin;

[assembly: OwinStartup(typeof(Startup))]

namespace Albatross.Example.API.Config
{
    public class Startup
    {
        private static readonly IUnityContainer _container = UnityHelpers.GetConfiguredContainer();

        public static void StartServer()
        {
            string baseAddress = "http://localhost:8081/";
            var startup = _container.Resolve<Startup>();
            IDisposable webApplication = WebApp.Start(baseAddress, startup.Configuration);

            try
            {
                Console.WriteLine("Started...");
                Console.ReadKey();
            }
            finally
            {
                webApplication.Dispose();
            }
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer());
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new UnityHubActivator(UnityHelpers.GetConfiguredContainer()));

            RegisterFilterProviders(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);
            appBuilder.UseCors(CorsOptions.AllowAll);

            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };

            appBuilder.MapSignalR(hubConfiguration);
        }

        private static void RegisterFilterProviders(HttpConfiguration config)
        {
            // Add Unity filters provider
            var providers = config.Services.GetFilterProviders().ToList();
            config.Services.Add(typeof(IFilterProvider), new WebApiUnityActionFilterProvider(UnityHelpers.GetConfiguredContainer()));
            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);
        }

    }
}
