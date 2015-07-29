using System.Collections.Generic;
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
        public async void CanGet()
        {
            var results = _repository.Get();
            Assert.Equal(6, await results.ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanGetSingleItem()
        {
            var result = await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == 1);
            Assert.Equal("Test1", result.Name);
        }

        [Fact]
        public async void CanNotGetInvalidItem()
        {
            var result = await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == 1000);
            Assert.Equal(null, result);
        }

        [Fact]
        public async void CanCreate()
        {
            var newModel = new ToDo() { Id = 100, Name = "TestNew", Priority = 100 };
            _repository.Create(newModel);
            Assert.Equal(7, await _repository.Get().ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanCreateMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = 100, Name = "TestNew", Priority = 100},
                new ToDo() {Id = 101, Name = "TestNew2", Priority = 101},
            };
            _repository.Create(newModels);
            Assert.Equal(8, await _repository.Get().ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanUpdate()
        {
            var newModel = new ToDo() { Id = 1, Name = "TestNew", Priority = 100 };
            _repository.Update(newModel);
            Assert.Equal("TestNew", (await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == 1)).Name);
        }

        [Fact]
        public async void CanUpdateMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = 1, Name = "TestNew", Priority = 100},
                new ToDo() {Id = 2, Name = "TestNew2", Priority = 100}
            };
            _repository.Update(newModels);
            Assert.Equal("TestNew", (await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == 1)).Name);
            Assert.Equal("TestNew2", (await _repository.Get().FirstOrDefaultAsync(todo => todo.Id == 2)).Name);
        }

        [Fact]
        public async void CanDelete()
        {
            var newModel = new ToDo() { Id = 1, Name = "TestNew", Priority = 100 };
            _repository.Delete(newModel);
            Assert.Equal(5, await _repository.Get().ToAsyncEnumerable().Count());
        }

        [Fact]
        public async void CanDeleteMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = 1, Name = "TestNew", Priority = 100},
                new ToDo() {Id = 2, Name = "TestNew2", Priority = 101},
            };
            _repository.Delete(newModels);
            Assert.Equal(4, await _repository.Get().ToAsyncEnumerable().Count());
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
