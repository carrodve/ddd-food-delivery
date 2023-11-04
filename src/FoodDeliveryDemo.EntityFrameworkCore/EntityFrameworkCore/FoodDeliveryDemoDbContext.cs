using FoodDeliveryDemo.EntityFrameworkCore.Configuration;
using FoodDeliveryDemo.Orders;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryDemo.EntityFrameworkCore
{
    public class FoodDeliveryDemoDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public FoodDeliveryDemoDbContext(DbContextOptions<FoodDeliveryDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
