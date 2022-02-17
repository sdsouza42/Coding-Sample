using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClientApp.Models
{
    [Table("OrderDetail")]
    public class Order
    {
        [Column("OrderNo")]
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [Column("ProductNo")]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    [Table("Product")]
    public class Product
    {
        [Display(Name = "Product No")]
        [Column("ProductNo")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Unit Price")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Current Stock")]
        [Required][Range(5, 50)]
        public int Stock { get; set; }

        //non-virtual navigation property - will require explicit loading of child entities
        public ICollection<Order> Orders { get; set; }

        public Product()
        {
            this.Orders = new List<Order>();
        }
    }

    public class Counter
    {
        public string Id { get; set; }

        public int CurrentValue { get; set; }
    }

    public class ShopEntities : DbContext
    {
        public ShopEntities() : base(Properties.Settings.Default.ShopConnectionString)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Counter> Counters { get; set; }
    }
}