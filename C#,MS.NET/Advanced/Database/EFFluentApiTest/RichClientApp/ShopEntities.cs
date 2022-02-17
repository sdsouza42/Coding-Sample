using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RichClientApp
{
    public class InvoiceEntry
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }

    public class Customer
    {
        public string CustomerId { get; set; }

        public decimal Credit { get; set; }

        public ICollection<InvoiceEntry> InvoiceEntries { get; set; }

        public Customer()
        {
            this.InvoiceEntries = new List<InvoiceEntry>();
        }
    }

    public class ShopEntities : DbContext
    {
        public ShopEntities() : base(Properties.Settings.Default.ShopConnectionString)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<InvoiceEntry>()
                .ToTable("Invoice")
                .Property(p => p.Id)
                .HasColumnName("OrderNo");
        }

    }
}
