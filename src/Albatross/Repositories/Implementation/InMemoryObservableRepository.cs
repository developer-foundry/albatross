using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Albatross.Models;
using Albatross.Repositories.Interfaces;

namespace Albatross.Repositories.Implementation
{
    public class InMemoryObservableRepository<T> : IAlbatrossObservableRepository<T> where T : class, IAlbatrossEntity
    {
        private readonly ObservableCollection<T> _repository;

        public InMemoryObservableRepository()
        {
            _repository = new ObservableCollection<T>();
        }

        public IObservable<T> Get()
        {
            return _repository.ToObservable();
        }

        public void Create(T item)
        {
            _repository.Add(item);
        }

        public void Create(IEnumerable<T> items)
        {
            foreach (var item in items)
                Create(item);
        }

        public void Update(T item)
        {
            int i = _repository.IndexOf(item);
            _repository.RemoveAt(i);
            _repository.Add(item);
        }

        public void Update(IEnumerable<T> items)
        {
            foreach (var item in items)
                Update(item);
        }

        public void Delete(T item)
        {
            _repository.Remove(item);
        }

        public void Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
                Delete(item);
        }
    }
}
