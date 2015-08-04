using System.Collections.Generic;
using Albatross.Models;
using Albatross.Repositories.Interfaces;
using Albatross.Services.Interfaces;

namespace Albatross.Services.Implementation
{
    public class AlbatrossEnumerableService<T> : IAlbatrossService<T> where T : class, IAlbatrossEntity
    {
        private readonly IAlbatrossEnumerableRepository<T> _enumerableRepository;

        public AlbatrossEnumerableService(IAlbatrossEnumerableRepository<T> enumerableRepository)
        {
            _enumerableRepository = enumerableRepository;
        }

        public IEnumerable<T> Get()
        {
            return _enumerableRepository.Get();
        }

        public void Create(T item)
        {
            _enumerableRepository.Create(item);
        }

        public void Create(IEnumerable<T> items)
        {
            _enumerableRepository.Create(items);
        }

        public void Update(T item)
        {
            _enumerableRepository.Update(item);
        }

        public void Update(IEnumerable<T> items)
        {
            _enumerableRepository.Update(items);
        }

        public void Delete(T item)
        {
            _enumerableRepository.Delete(item);
        }

        public void Delete(IEnumerable<T> items)
        {
            _enumerableRepository.Delete(items);
        }
    }
}
