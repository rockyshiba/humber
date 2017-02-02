using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week4b.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}