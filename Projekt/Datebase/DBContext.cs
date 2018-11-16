using Projekt.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Datebase
{
    public class DBContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

      
        

     
    }

}