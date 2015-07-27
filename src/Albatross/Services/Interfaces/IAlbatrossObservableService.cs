using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Services.Interfaces
{
    public interface IAlbatrossObservableService<T> where T : class
    {
        IObservable<T> Get();
        void Create(T item);
        void Create(IEnumerable<T> items);
        void Update(T item);
        void Update(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
    }
}
