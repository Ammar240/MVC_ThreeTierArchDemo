using BuisnessAccessLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly MVCPracticeDBContext _dbContext;

        public GenericRepository(MVCPracticeDBContext context)
        {
            _dbContext = context;
        }

        public int Add(T T)
        {
            _dbContext.Set<T>().Add(T);
            return _dbContext.SaveChanges();
        }

        public int Delete(T T)
        {
            _dbContext.Set<T>().Remove(T);
            return _dbContext.SaveChanges();
        }

        public T Get(int? id)
        {
            //    var T = (from dept in _dbContext.Set<T>()
            //                      where dept.Id == id
            //                      select dept).FirstOrDefault();
            //    return T;
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            //var T = from dept in _dbContext.Set<T>()
            //                 select dept;
            //return T;
            return _dbContext.Set<T>().ToList<T>();
        }

        public int Update(T T)
        {
            _dbContext.Set<T>().Update(T);
            return _dbContext.SaveChanges();
        }

    }
}
