using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RethinkDb;
using RethinkDb.Configuration;
using RethinkDb.ConnectionFactories;

namespace Albatross.Repositories
{
    public class ReThinkDbRepository<T> : IAlbatrossRepository<T> where T : class
    {
        private readonly IDatabaseQuery _db;
        private readonly ITableQuery<T> _table;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _conn;
        public ReThinkDbRepository(string databaseName)
        {
            _db = Query.Db(databaseName);
            _table = _db.Table<T>(typeof (T).Name.ToLower());
            _connectionFactory = new DefaultConnectionFactory(
                new List<EndPoint>()
                {
                    new IPEndPoint(IPAddress.Parse("192.168.59.103"), 49153)
                });
            _conn = _connectionFactory.Get();
        }

        public IEnumerable<T> Get()
        {
            return _conn.Run(_table);
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
