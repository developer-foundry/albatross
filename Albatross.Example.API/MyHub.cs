using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalR_Rx_SelfHost_Example
{
    public class MyHub : Hub
    {
        /*private readonly ITickerService _serivce;
        private readonly Random _random = new Random();
        private IObservable<Stock> liveSequence;
 
        public MyHub(ITickerService tickerService)
        {
            _serivce = tickerService;
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Task.Factory.StartNew(Action);

            return Clients.All.connected(Context.ConnectionId, DateTime.Now.ToString());
        }

        private void Action()
        {
            liveSequence = _serivce.GetStocks();
            liveSequence.TakeWhile((val) => val.Value != -1).Subscribe(s => Send(s.Symbol, s.Value),
                ex => Console.WriteLine("OnError: {0}", ex.Message),
                () => Console.WriteLine("OnCompleted"));

            while (true)
            {
                var t = new Stock() { Symbol = "GOOG", Value = _random.Next(1, 100) };
                _serivce.CreateStock(t);
                Thread.Sleep(3000);
            }
        }


        public void Send(string symbol, decimal value)
        {
            Clients.All.addMessage(symbol, value);
        }*/
    }
}
