using FoodDeliveryDemo.Orders;
using System;

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
    }
}
