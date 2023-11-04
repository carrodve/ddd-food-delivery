using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class CreateOrderDto
    {
        public string Customer { get; set; }

        public string Comments { get; set; }

        public OrderState State { get; set; }

        public GeoCoordinate DeliveryLocation { get; set; }

        public int? VehicleId { get; set; }
    }
}
