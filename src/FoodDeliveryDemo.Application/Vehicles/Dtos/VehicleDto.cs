using FoodDeliveryDemo.Configuration;
using System;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public GeoCoordinate CurrentLocation { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
