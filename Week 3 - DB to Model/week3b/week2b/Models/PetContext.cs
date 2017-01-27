using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace week2b.Models
{
    public class PetContext : DbContext
    {
        //The purpose of this class is to match model and database
        public DbSet<Pet> Pets { get; set; }
    }
}