using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week2a.Models
{
    public class PetContext : DbContext
    {
        public DbSet <Pet> Pets { get; set; }
        //the purpose of this class is to use model to represent database contents
    }
}