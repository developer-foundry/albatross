using System.Linq;
using System.Reactive.Linq;
using Albatross.Repositories.Implementation;
using Albatross.Repositories.Interfaces;
using Albatross.Tests.Unit.Models;
using Xunit;

namespace Albatross.Tests.Unit.Repositories
{
    public class InMemoryObservableRepositoryTests
    {
        private readonly IAlbatrossObservableRepository<ToDo> _repository;

        public InMemoryObservableRepositoryTests()
        {
            _repository = new InMemoryObservableRepository<ToDo>();

            SeedData();
        }

        [Fact]
        public void CanGet()
        {
            var results = _repository.Get();
            Assert.Equal(6, results.ToEnumerable().Count());
        }

        private void SeedData()
        {
            _repository.Create(new ToDo() { Id = 1, Name = "Test1", Priority = 1 });
            _repository.Create(new ToDo() { Id = 2, Name = "Test2", Priority = 2 });
            _repository.Create(new ToDo() { Id = 3, Name = "Test3", Priority = 3 });
            _repository.Create(new ToDo() { Id = 4, Name = "Test4", Priority = 4 });
            _repository.Create(new ToDo() { Id = 5, Name = "Test5", Priority = 5 });
            _repository.Create(new ToDo() { Id = 6, Name = "Test6", Priority = 6 });
        }
    }
}
