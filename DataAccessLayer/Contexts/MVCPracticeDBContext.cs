using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccessLayer.Contexts
{
    public class MVCPracticeDBContext : DbContext
    {
        public MVCPracticeDBContext(DbContextOptions<MVCPracticeDBContext> options): base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server =.; Database = MVCPracticeDB; Trusted_Connection = true;");

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
