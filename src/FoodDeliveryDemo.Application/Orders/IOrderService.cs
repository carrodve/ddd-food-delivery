using FoodDeliveryDemo.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto input);

        Task<OrderDto> UpdateAsync(Guid id, UpdateOrderDto input);

        Task DeleteAsync(Guid id);
    }
}
