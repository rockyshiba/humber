using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week4b.Models
{
    public class CompanyContext : DbContext
    {
        //Access employees from database through Employee class
        public DbSet<Employee> Employees { get; set; }
        //Access employees from database through Department class
        public DbSet<Department> Departments { get; set; }
    }
}