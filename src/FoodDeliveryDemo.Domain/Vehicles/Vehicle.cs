using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.History;
using System.Collections.Generic;

namespace FoodDeliveryDemo.Vehicles
{
    /// <summary>
    /// Entidad vehiculo/conductor auditable con identificador único de tipo int.
    /// </summary>
    public class Vehicle : AuditableEntity<int>
    {
        /// <summary>
        /// Ubicación actual
        /// </summary>
        public GeoCoordinate CurrentLocation { get; set; }

        /// <summary>
        /// Historial de ubicaciones
        /// </summary>
        public ICollection<VehicleLocationHistory> LocationHistory { get; set; }

        public Vehicle()
        { 
        }

        public Vehicle(int id, GeoCoordinate currentLocation)
        {
            Id = id;
            CurrentLocation = currentLocation;
        }
    }
}
