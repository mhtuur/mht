using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MehmetApp.MVCUI.Models;

namespace MehmetApp.MVCUI.Entity
{
    public class DataContext : DbContext
    {
        public DataContext():base("DataConnection")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines  { get; set; }
    }
}