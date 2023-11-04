using System;

namespace FoodDeliveryDemo.Vehicles.Dtos
{
    public class VehicleDto : CreateOrUpdateVehicleDto
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
