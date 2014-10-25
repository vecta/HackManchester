using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

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
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
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

        //public IEnumerable<T> GetAll()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).ToList();
        }
    }
}
