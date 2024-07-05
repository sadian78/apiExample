using ExampleWebApiCore.DataLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.DataLayer.Context
{
    public class ExampleWebApiContext : DbContext
    {
        public ExampleWebApiContext(DbContextOptions<ExampleWebApiContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalePerson> SalePersons { get; set; }
        public virtual DbSet<OrderItemSingle> orderItemSingles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemSingle>().HasKey(o =>
            new { o.ProductId, o.OrderItemId });
        }

    }
}
