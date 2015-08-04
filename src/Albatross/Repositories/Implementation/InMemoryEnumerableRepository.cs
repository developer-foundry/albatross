using System.Collections.Generic;
using System.Linq;
using Albatross.Models;
using Albatross.Repositories.Interfaces;
using RethinkDb.QueryTerm;

namespace Albatross.Repositories.Implementation
{
    public class InMemoryEnumerableRepository<T> : IAlbatrossEnumerableRepository<T> where T : class, IAlbatrossEntity
    {
        private readonly IList<T> _repository = new List<T>();

        public IEnumerable<T> Get()
        {
            return _repository;
        }

        public void Create(T item)
        {
            if (!Get().Any(e => e.Equals(item)))
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
