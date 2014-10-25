using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Kitbag.Database
{
    public class Repository<T> where T : class 
    {
        private readonly CwonData _dbContext;

        public Repository(CwonData dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T item)
        {
            Update(item);
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().AddOrUpdate();
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
    }
}
