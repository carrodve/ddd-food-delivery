using FoodDeliveryDemo.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderService
    {
        Task<GetOrderAndVehicleLocationDto> GetOrderAndVehicleLocationByIdAsync(Guid id);

        Task CreateOrderAsync(CreateOrderDto input);

        Task<OrderDto> UpdateDeliveryLocationAsync(Guid id, UpdateOrderDeliveryLocationDto input);

        Task DeleteOrderAsync(Guid id);
    }
}
