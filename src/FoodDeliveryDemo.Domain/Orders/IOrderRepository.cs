using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderRepository
    {
        Task InsertAsync(Order entity);

        Task<Order> GetByIdAsync(Guid id);

        Task<List<Order>> GetAllAsync();
    }
}
