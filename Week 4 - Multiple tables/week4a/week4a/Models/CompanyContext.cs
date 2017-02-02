using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week4a.Models
{
    public class CompanyContext : DbContext
    {
        //property: Employees from the Emmployee class from the database
        public DbSet<Employee> Employees { get; set; }
        //property: Departments from the Department class from the database
        public DbSet<Department> Departments { get; set; }
    }
}