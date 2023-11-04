using FoodDeliveryDemo.Configuration;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class CreateOrUpdateVehicleDto
    {
        public GeoCoordinate CurrentLocation { get; set; }
    }
}
