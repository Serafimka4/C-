using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebShop.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebShop.DAL
{
    public class ShopContext : DbContext
    {
        public DbSet<Ok> OkOperation { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}