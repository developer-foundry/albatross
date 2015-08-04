using System.Collections.Generic;
using Albatross.Models;
using Albatross.Repositories.Interfaces;
using Microsoft.Data.Entity;

namespace Albatross.Repositories.Implementation
{
    public class EntityFrameworkEnumerableRepository<T> : IAlbatrossEnumerableRepository<T> where T : class, IAlbatrossEntity
    {
        protected readonly DbContext DbContext;

        public EntityFrameworkEnumerableRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<T> Get()
        {
            return DbContext.Set<T>();
        }

        public void Create(T item)
        {
            DbContext.Set<T>().Add(item);
            DbContext.SaveChanges();
        }

        public void Create(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                DbContext.Set<T>().Add(item);
            }
            DbContext.SaveChanges();
        }

        public void Update(T item)
        {
            DbContext.Entry(item).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Update(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                DbContext.Entry(item).State = EntityState.Modified;
            }
            DbContext.SaveChanges();
        }

        public void Delete(T item)
        {
            DbContext.Set<T>().Remove(item);
            DbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                DbContext.Set<T>().Remove(item);
            }
            DbContext.SaveChanges();
        }
    }
}
