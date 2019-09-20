using BMS.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BMS.Repository
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("ProjectDbContext") { }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Suplier> Supliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }

        //internal void Stocks(Stock stockModel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}