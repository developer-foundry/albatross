using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Models;
using Albatross.Repositories.Interfaces;
using Microsoft.Framework.OptionsModel;
using RethinkDb;
using RethinkDb.ConnectionFactories;
using RethinkDb.QueryTerm;

namespace Albatross.Repositories.Implementation
{
    public class RethinkDbObservableRepository<T> : IAlbatrossObservableRepository<T> where T : class, IAlbatrossEntity
    {
        private readonly IDatabaseQuery _db;
        private readonly TableQuery<T> _table;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _conn;
        private readonly CancellationTokenSource stopMonitor = new CancellationTokenSource();

        public RethinkDbObservableRepository(IOptions<RethinkConfiguration> settings)
        {
            _db = Query.Db(settings.Options.Database);
            _table = _db.Table<T>(typeof(T).Name.ToLower());
            _connectionFactory = new DefaultConnectionFactory(
                new List<EndPoint>()
                {
                    new IPEndPoint(IPAddress.Parse(settings.Options.IpAddress), settings.Options.Port)
                });
            _conn = _connectionFactory.Get();

            var changefeedThread = new Thread(ChangeFeedMonitor);
            changefeedThread.Start();
        }

        public IObservable<T> Get()
        {
            var results = _conn.Run(_table).ToList();
            return results.ToObservable();
        }

        public void Create(T item)
        {
            _conn.Run(_table.Insert(item));
        }

        public void Create(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        private void ChangeFeedMonitor()
        {
            try
            {
                foreach (var change in _conn.Run(_table.Changes(), cancellationToken: stopMonitor.Token))
                {
                    string type;
                    Guid id;
                    if (change.NewValue == null)
                    {
                        type = "DELETE";
                        id = change.OldValue.Id;
                    }
                    else if (change.OldValue == null)
                    {
                        type = "INSERT";
                        id = change.NewValue.Id;
                    }
                    else
                    {
                        type = "UPDATE";
                        id = change.NewValue.Id;
                    }

                    Console.WriteLine("{0}: Monitored change to Person table, {1} of id {2}", DateTime.Now, type, id);
                }
            }
            catch (AggregateException ex)
            {
                if (!(ex.InnerException is TaskCanceledException))
                    throw;
            }
        }
    }
}
