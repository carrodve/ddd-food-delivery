using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implementa <see cref="IVehicleRepository"/> para EntityFrameworkCore.
    /// </summary>
    public class VehicleRepository : FoodDeliveryDemoRepositoryBase<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(FoodDeliveryDemoDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
