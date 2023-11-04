using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Domain.Entities;

namespace FoodDeliveryDemo.Vehicles
{
    public class Vehicle : AuditableEntity<int>
    {
        /// <summary>
        /// Ubicación actual
        /// </summary>
        public GeoCoordinate CurrentLocation { get; set; }

        /// <summary>
        /// Historial de ubicaciones
        /// </summary>
       //public List<VehicleLocationHistory> LocationHistory { get; set; }
    }
}
