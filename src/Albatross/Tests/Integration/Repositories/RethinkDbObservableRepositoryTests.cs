using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Configuration;
using Albatross.Repositories.Implementation;
using Albatross.Repositories.Interfaces;
using Albatross.Tests.Unit.Models;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.OptionsModel;
using Moq;
using Xunit;

namespace Albatross.Tests.Integration.Repositories
{
    public class RethinkDbObservableRepositoryTests
    {
        private readonly IAlbatrossObservableRepository<ToDo> _repository;
        private readonly Mock<IOptions<RethinkConfiguration>> _options;

        public RethinkDbObservableRepositoryTests()
        {
            _options = new Mock<IOptions<RethinkConfiguration>>();
            _options.SetupGet(x => x.Options).Returns(new RethinkConfiguration()
            {
                Database = "albatross",
                IpAddress = "192.168.59.103",
                Port = 28015
            });

            _repository = new RethinkDbObservableRepository<ToDo>(_options.Object);
        }

        [Fact]
        public void CanConnectToDb()
        {
            Assert.NotNull(_repository);
        }

    }
}
