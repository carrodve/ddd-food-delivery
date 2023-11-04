using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.Vehicles;
using System;

namespace FoodDeliveryDemo.History
{
    public class VehicleLocationHistory : Entity<int>
    {
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime CreationTime { get; set; }
        
        //public GeoCoordinate Location { get; set; }
    }
}
