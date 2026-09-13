using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessAccessLayer.Interfaces
{
    public interface IDepartmentRepository
    {
        // Add 5 signature methods
        IEnumerable<Department> GetAll();
        Department Get(int id);
        int Add(Department department);
        int Update(Department department);
        int Delelte(Department department);
    }
}
