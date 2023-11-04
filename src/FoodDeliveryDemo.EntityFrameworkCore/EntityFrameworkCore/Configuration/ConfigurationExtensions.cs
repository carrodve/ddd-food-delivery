using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryDemo.EntityFrameworkCore.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(v =>
            {
                v.HasKey(v => v.Id);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(v => v.Id);
            });


           // modelBuilder.Entity<Order>()
           //.HasOne(o => o.Vehicle) // Propiedad de navegación hacia Vehicle
           //.WithMany()
           //.IsRequired(false) // Opcional si no todos los pedidos están asociados a un vehículo
           //.OnDelete(DeleteBehavior.Cascade); // Habilita la eliminación en cascada
        }
    }
}
