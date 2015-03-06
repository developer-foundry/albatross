using System;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Owin;
using Microsoft.Owin.Cors;
using SignalR_Rx_SelfHost_Domain;
using SignalR_Rx_SelfHost_Services;
using Unity.SelfHostWebApiOwin;


namespace SignalRSelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            Startup.StartServer();
        }
    }
}