using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Repositories.Implementation;
using Albatross.Repositories.Interfaces;
using Albatross.Tests.Unit.Models;
using Xunit;

namespace Albatross.Tests.Unit.Repositories
{
    public class InMemoryEnumerableRepositoryTests
    {
        private readonly IAlbatrossEnumerableRepository<ToDo> _repository;

        public InMemoryEnumerableRepositoryTests()
        {
            _repository = new InMemoryEnumerableRepository<ToDo>();

            SeedData();
        }

        [Fact]
        public void CanGet()
        {
            var results = _repository.Get();
            Assert.Equal(6, results.Count());
        }

        [Fact]
        public void CanGetSingleItem()
        {
            var result = _repository.Get().FirstOrDefault(todo => todo.Id == Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"));
            Assert.Equal("Test1", result.Name);
        }

        [Fact]
        public void CanNotGetInvalidItem()
        {
            var result = _repository.Get().FirstOrDefault(todo => todo.Id == Guid.NewGuid());
            Assert.Equal(null, result);
        }

        [Fact]
        public void CanCreate()
        {
            var newModel = new ToDo() {Id = Guid.NewGuid(), Name = "TestNew", Priority = 100};
            _repository.Create(newModel);
            Assert.Equal(7, _repository.Get().Count());
        }

        [Fact]
        public void CanCreateMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = Guid.NewGuid(), Name = "TestNew", Priority = 100},
                new ToDo() {Id = Guid.NewGuid(), Name = "TestNew2", Priority = 101},
            };
            _repository.Create(newModels);
            Assert.Equal(8, _repository.Get().Count());
        }

        [Fact]
        public void CanUpdate()
        {
            var newModel = new ToDo() { Id = Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"), Name = "TestNew", Priority = 100 };
            _repository.Update(newModel);
            Assert.Equal("TestNew", _repository.Get().FirstOrDefault(todo => todo.Id == Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B")).Name);
        }

        [Fact]
        public void CanUpdateMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"), Name = "TestNew", Priority = 100},
                new ToDo() {Id = Guid.Parse("96A62896-7536-4388-9BFA-62841F38C3FB"), Name = "TestNew2", Priority = 100}
            };
            _repository.Update(newModels);
            Assert.Equal("TestNew", _repository.Get().FirstOrDefault(todo => todo.Id == Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B")).Name);
            Assert.Equal("TestNew2", _repository.Get().FirstOrDefault(todo => todo.Id == Guid.Parse("96A62896-7536-4388-9BFA-62841F38C3FB")).Name);
        }

        [Fact]
        public void CanDelete()
        {
            var newModel = new ToDo() { Id = Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"), Name = "TestNew", Priority = 100 };
            _repository.Delete(newModel);
            Assert.Equal(5, _repository.Get().Count());
        }

        [Fact]
        public void CanDeleteMultiple()
        {
            var newModels = new List<ToDo>()
            {
                new ToDo() {Id = Guid.Parse("9EE1282A-309B-4A37-A914-10FAA38A655B"), Name = "TestNew", Priority = 100},
                new ToDo() {Id = Guid.Parse("96A62896-7536-4388-9BFA-62841F38C3FB"), Name = "TestNew2", Priority = 101},
            };
            _repository.Delete(newModels);
            Assert.Equal(4, _repository.Get().Count());
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
    }
}
