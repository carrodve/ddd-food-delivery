using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class GetOrderAndVehicleLocationDto
    {
        public GeoCoordinate DeliveryLocation { get; set; }

        public GeoCoordinate CurrentLocation { get; set; }
    }
}
