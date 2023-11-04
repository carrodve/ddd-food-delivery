using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class UpdateOrderDeliveryLocationDto
    {
        public GeoCoordinate DeliveryLocation { get; set; }
    }
}
