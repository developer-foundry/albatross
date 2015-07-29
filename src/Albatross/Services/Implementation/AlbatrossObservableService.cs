using System;
using System.Collections.Generic;
using Albatross.Repositories.Interfaces;
using Albatross.Services.Interfaces;

namespace Albatross.Services.Implementation
{
    public class AlbatrossObservableService<T> : IAlbatrossObservableService<T> where T : class
    {
        private readonly IAlbatrossObservableRepository<T> _repository;

        public AlbatrossObservableService(IAlbatrossObservableRepository<T> repository)
        {
            _repository = repository;
        }

        public IObservable<T> Get()
        {
            return _repository.Get();
        }

        public void Create(T item)
        {
            _repository.Create(item);
        }

        public void Create(IEnumerable<T> items)
        {
            _repository.Create(items);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }

        public void Update(IEnumerable<T> items)
        {
            _repository.Update(items);
        }

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public void Delete(IEnumerable<T> items)
        {
            _repository.Delete(items);
        }
    }
}
