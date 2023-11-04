using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderRepository
    {
        Task InsertAsync(Order entity);

        Task UpdateAsync(Order entity);

        Task DeleteAsync(Guid id);

        Task<Order> GetByIdAsync(Guid id);

        Task<Order> FindByIdAsync(Guid id);

        Task<Order> GetOrderWithVehicleAsync(Guid id);

        Task<List<Order>> GetAllListAsync();
    }
}
