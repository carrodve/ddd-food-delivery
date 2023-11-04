using FoodDeliveryDemo.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto input);

        Task<OrderDto> UpdateOrderAsync(Guid id, UpdateOrderDto input);
    }
}
