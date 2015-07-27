using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Hubs.Interfaces
{
    public interface IAlbatrossHub<T> where T : class
    {
        void Created(T created);
        void Deleted(T deleted);
        void Updated(T updated);
    }
}
