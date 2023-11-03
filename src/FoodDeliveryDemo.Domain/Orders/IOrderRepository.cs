using GeoCoordinatePortable;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);

        Task DeleteOrderAsync(int orderId);

        Task UpdateOrderLocationAsync(int orderId, GeoCoordinate newLocation);

        Task<Order> GetOrderLocationByOrderIdAsync(int orderId);
    }
}
