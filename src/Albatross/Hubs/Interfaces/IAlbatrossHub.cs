using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Hubs.Interfaces
{
    public interface IAlbatrossHub<T> where T : class
    {
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
