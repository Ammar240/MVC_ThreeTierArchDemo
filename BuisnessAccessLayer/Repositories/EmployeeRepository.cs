using BuisnessAccessLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        #region Non Generic
        //private readonly MVCPracticeDBContext _dbContext;

        //public EmployeeRepository(MVCPracticeDBContext context)
        //{
        //    _dbContext = context;
        //}

        //public int Add(Employee employee)
        //{
        //    _dbContext.Employees.Add(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _dbContext.Employees.Remove(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public Employee Get(int? id)
        //{
        //    //    var employee = (from dept in _dbContext.employees
        //    //                      where dept.Id == id
        //    //                      select dept).FirstOrDefault();
        //    //    return employee;
        //    return _dbContext.Employees.Where(D => D.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    //var employee = from dept in _dbContext.employees
        //    //                 select dept;
        //    //return employee;
        //    return _dbContext.Employees.ToList<Employee>();
        //}

        //public int Update(Employee employee)
        //{
        //    _dbContext.Employees.Update(employee);
        //    return _dbContext.SaveChanges();
        //}

        #endregion

        public EmployeeRepository(MVCPracticeDBContext context):base(context)
        {
            Context = context;
        }

        public MVCPracticeDBContext Context { get; }

        public IEnumerable<Employee> SearchEmployee(string value)
        {
            return Context.Employees.Where(E => E.Name.Contains(value));
        }
    }
}
