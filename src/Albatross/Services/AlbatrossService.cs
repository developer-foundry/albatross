using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Albatross.Repositories;

namespace Albatross.Services
{
    public class AlbatrossService<T> : IAlbatrossService<T> where T : class
    {
        private readonly IAlbatrossRepository<T> _repository;

        protected AlbatrossService(IAlbatrossRepository<T> repository)
        {
            _repository = repository;
        }

        public IQueryable<T> Get()
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
