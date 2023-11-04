using FoodDeliveryDemo.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implementa <see cref="IOrderRepository"/> para EntityFrameworkCore.
    /// </summary>
    public class OrderRepository : FoodDeliveryDemoRepositoryBase<Order, Guid>, IOrderRepository
    {
        public OrderRepository(FoodDeliveryDemoDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<Order> GetOrderWithVehicleAsync(Guid id)
        {
            var result = await DbContext.Orders
                .Include(o => o.Vehicle)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
