using FoodDeliveryDemo.Orders.Dtos;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto input);
    }
}
