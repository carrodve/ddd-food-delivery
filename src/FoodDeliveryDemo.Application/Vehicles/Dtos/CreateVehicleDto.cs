using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class CreateVehicleDto
    {
        public int Id { get; set; }

        public GeoCoordinate CurrentLocation { get; set; }
    }
}
