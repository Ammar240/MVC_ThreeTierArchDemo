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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVCPracticeDBContext _dbContext;

        public DepartmentRepository(MVCPracticeDBContext dbContext)
        {
            //context = new MVCPracticeDBContext(); => need to be created by CLR to change the same database
            //not new object for each repository (Dependecy injection)

            _dbContext = dbContext; // -> CLR creates it (inject it into Default constructor of repo) (Dependency injection)
        }
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Delelte(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public Department Get(int? id)
        {
            //    var department = (from dept in _dbContext.Departments
            //                      where dept.Id == id
            //                      select dept).FirstOrDefault();
            //    return department;
            return _dbContext.Departments.Where(D => D.Id == id).FirstOrDefault();
        }

        public IEnumerable<Department> GetAll()
        {
            //var department = from dept in _dbContext.Departments
            //                 select dept;
            //return department;
            return _dbContext.Departments.ToList<Department>();
        }

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
    }
}
