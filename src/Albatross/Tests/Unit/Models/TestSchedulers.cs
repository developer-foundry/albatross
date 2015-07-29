using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using Albatross.Tests.Unit.Models.Interfaces;
using Microsoft.Reactive.Testing;

namespace Albatross.Tests.Unit.Models
{
    public sealed class TestSchedulers : ISchedulerProvider
    {
        #region Explicit implementation of ISchedulerService
        IScheduler ISchedulerProvider.CurrentThread => CurrentThread;
        IScheduler ISchedulerProvider.Dispatcher => Dispatcher;
        IScheduler ISchedulerProvider.Immediate => Immediate;
        IScheduler ISchedulerProvider.NewThread => NewThread;
        IScheduler ISchedulerProvider.ThreadPool => ThreadPool;
        #endregion

        public TestScheduler CurrentThread { get; } = new TestScheduler();
        public TestScheduler Dispatcher { get; } = new TestScheduler();
        public TestScheduler Immediate { get; } = new TestScheduler();
        public TestScheduler NewThread { get; } = new TestScheduler();
        public TestScheduler ThreadPool { get; } = new TestScheduler();
    }
}
