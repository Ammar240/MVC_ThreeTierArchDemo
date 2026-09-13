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
    internal class DepartmentRepository : IDepartmentRepository
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
            throw new NotImplementedException();
        }

        public int Delelte(Department department)
        {
            throw new NotImplementedException();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
