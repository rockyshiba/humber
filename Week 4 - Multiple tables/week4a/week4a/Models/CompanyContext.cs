using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week4a.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}