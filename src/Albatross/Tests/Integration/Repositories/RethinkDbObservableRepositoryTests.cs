using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Repositories.Implementation;
using Albatross.Repositories.Interfaces;
using Albatross.Tests.Unit.Models;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.OptionsModel;
using Moq;
using RethinkDb;
using RethinkDb.ConnectionFactories;
using Xunit;

namespace Albatross.Tests.Integration.Repositories
{
    public class RethinkDbObservableRepositoryTests : IDisposable
    {
        private readonly IAlbatrossObservableRepository<ToDo> _repository;
        private readonly Mock<IOptions<RethinkConfiguration>> _options;
        private const string DatabaseName = "rethinkintegrationtest";
        private const string TableName = "todo";
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _conn;

        public static IDatabaseQuery Db = Query.Db(DatabaseName);
        public static ITableQuery<ToDo> Table = Db.Table<ToDo>(TableName);

        public RethinkDbObservableRepositoryTests()
        {
            _options = new Mock<IOptions<RethinkConfiguration>>();
            _options.SetupGet(x => x.Options).Returns(new RethinkConfiguration()
            {
                Database = DatabaseName,
                IpAddress = "192.168.59.103",
                Port = 28015
            });

            _connectionFactory = new DefaultConnectionFactory(
                new List<EndPoint>()
                {
                    new IPEndPoint(IPAddress.Parse(_options.Object.Options.IpAddress), _options.Object.Options.Port)
                });
            _conn = _connectionFactory.Get();

            _conn.Run(Query.DbCreate(DatabaseName));
            _conn.Run(Db.TableCreate(TableName));

            _repository = new RethinkDbObservableRepository<ToDo>(_options.Object);
            SeedData();
        }

        [Fact]
        public void CanConnectToDb()
        {
            Assert.NotNull(_repository);
        }

        [Fact]
        public async void CanGet()
        {
            var results = _repository.Get();
            Assert.Equal(6, await results.ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanGetSingleItem()
        {
            var result = await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"));
            Assert.Equal("Test1", result.Name);
        }

        [Fact]
        public async void CanGetBeReactive()
        {
            var results = _repository.Get();
            Assert.Equal(6, await results.ToAsyncEnumerable().Count());

            _repository.Create(new ToDo() { Id = Guid.Parse("56459C90-6158-4382-BABE-C87755644EE2"), Name = "Test6", Priority = 6 });
            Assert.Equal(7, await results.ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanNotGetInvalidItem()
        {
            var result = await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == Guid.NewGuid());
            Assert.Equal(null, result);
        }

        private void SeedData()
        {
            _repository.Create(new ToDo() { Id = Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"), Name = "Test1", Priority = 1 });
            _repository.Create(new ToDo() { Id = Guid.Parse("96A62896-7536-4388-9BFA-62841F38C3FB"), Name = "Test2", Priority = 2 });
            _repository.Create(new ToDo() { Id = Guid.Parse("D0863A75-99DC-4A10-ADBC-99340FC48BC0"), Name = "Test3", Priority = 3 });
            _repository.Create(new ToDo() { Id = Guid.Parse("B9F4E989-9575-4EE8-BF74-5DBFEFB08505"), Name = "Test4", Priority = 4 });
            _repository.Create(new ToDo() { Id = Guid.Parse("290FC44A-F641-45D4-BDE0-F3EC3A0B4CCE"), Name = "Test5", Priority = 5 });
            _repository.Create(new ToDo() { Id = Guid.Parse("08459C90-6158-4382-BABE-C87755644EE2"), Name = "Test6", Priority = 6 });
        }

        public void Dispose()
        {
            _conn.Run(Db.TableDrop(TableName));
            _conn.Run(Query.DbDrop(DatabaseName));
        }
    }
}
