using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer.Interfaces
{
    internal interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Department Get(int? id);
        int Add(Department employee);
        int Update(Department department);
        int Delelte(Department department);
    }
}
