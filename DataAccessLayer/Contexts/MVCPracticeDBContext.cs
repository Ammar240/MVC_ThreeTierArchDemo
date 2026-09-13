using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class MVCPracticeDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server =.; Database = MVCPracticeDB; Trustec_Connection = true;");

        public DbSet<Department> Departments { get; set; }

    }
}
