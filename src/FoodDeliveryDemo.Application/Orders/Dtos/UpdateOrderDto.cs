using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class UpdateOrderDto
    {
        public GeoCoordinate DeliveryLocation { get; set; }
    }
}
