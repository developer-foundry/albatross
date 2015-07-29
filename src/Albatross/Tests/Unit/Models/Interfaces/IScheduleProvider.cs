using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;

namespace Albatross.Tests.Unit.Models.Interfaces
{
    public interface ISchedulerProvider
    {
        IScheduler CurrentThread { get; }
        IScheduler Dispatcher { get; }
        IScheduler Immediate { get; }
        IScheduler NewThread { get; }
        IScheduler ThreadPool { get; }
    }
}
