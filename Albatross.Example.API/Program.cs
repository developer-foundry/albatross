﻿using System;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Albatross.Example.API.Config;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Owin;
using Microsoft.Owin.Cors;
using Unity.SelfHostWebApiOwin;


namespace Albatross.Example.API
{
    public class Program
    {
        static void Main(string[] args)
        {
            Startup.StartServer();
        }
    }
}