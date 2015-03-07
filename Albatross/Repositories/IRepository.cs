using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
        void Create(T item);
        void Create(IEnumerable<T> items);
        void Update(T item);
        void Update(IEnumerable<T> items);
        void Delete(T item);
        void Delete(IEnumerable<T> items);
        void Refresh(T item);
    }
}
