using Microsoft.EntityFrameworkCore;
using lacrosseDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace lacrosseDB
{
    /// <summary>
    /// The class that is responsible for connecting, updating the database 
    /// </summary>
    public class lacrosseContext : DbContext
    {
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Customer> Customer {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Manager> Managers {get; set;} 
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Balls> Balls {get; set;} 
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Sticks> Sticks {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Orders> Orders {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Locations> Locations {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Inventory> Inventory {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<Cart> Cart {get; set;}
        /// <summary>
        /// A table in the database 
        /// </summary>
        /// <value></value>
        public DbSet<CartItem> CartItem {get; set;}

        /// <summary>
        /// telling lacrosse context where the database is and then connecting to it 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("lacrosseDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        // will need this method for the inventory table 
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Inventory>() 
        //     .HasOne(p => p.Product)
        //     .WithMany(products => products.ProdName)
        //     .HasForeignKey(p => p.Id);

        //     modelBuilder.Entity<Inventory>() 
        //     .HasOne(o => o.Orders)
        //     .WithMany(orders => orders.OrderNum)
        //     .HasForeignKey(o => o.Id);
        //}
    }
}