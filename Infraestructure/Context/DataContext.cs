using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name= MyContextDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<SalesMan> SalesMans { get; set; }
    }
}
