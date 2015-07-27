using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Repositories.Interfaces;
using Microsoft.Framework.OptionsModel;
using RethinkDb;
using RethinkDb.ConnectionFactories;

namespace Albatross.Repositories
{
    public class RethinkDbObservableRepository<T> : IAlbatrossObservableRepository<T> where T : class
    {
        private readonly IDatabaseQuery _db;
        private readonly ITableQuery<T> _table;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _conn;

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
        }

        public IObservable<T> Get()
        {
            var results = _conn.Run(_table).ToList();
            return results.ToObservable();
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
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
    }
}
