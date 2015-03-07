using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public EntityFrameworkRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>();
        }

        public void Create(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
        }

        public void Create(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _dbContext.Set<T>().Add(item);
            }
            _dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Update(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            _dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _dbContext.Set<T>().Remove(item);
            }
            _dbContext.SaveChanges();
        }

        public void Refresh(T item)
        {
            _dbContext.Entry(item).Reload();
        }
    }
}
