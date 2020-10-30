using Microsoft.EntityFrameworkCore;
using lacrosseDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace lacrosseDB
{
    public class lacrosseContext : DbContext
    {
        /// <summary>
        /// the tables that will show up in pgadmin
        /// </summary>
        /// <value></value>
        public DbSet<Customer> products {get; set;}
        public DbSet<Manager> managers {get; set;} 
        public DbSet<Balls> balls {get; set;} 
        public DbSet<Sticks> sticks {get; set;} 
        public DbSet<Orders> orders {get; set;}
        public DbSet<Locations> locations {get; set;}

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
        // }
    }
}