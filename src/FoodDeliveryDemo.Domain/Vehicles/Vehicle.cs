using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.History;
using FoodDeliveryDemo.Orders;
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
        public double Latitude { get; set; }

        /// <summary>
        /// Ubicación actual
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Historial de ubicaciones
        /// </summary>
        public ICollection<VehicleLocationHistory> LocationHistory { get; set; }

        /// <summary>
        /// Colección de pedidos de la relación 1:N
        /// </summary>
        public ICollection<Order> Orders { get; set; }

        public Vehicle()
        { 
        }

        public Vehicle(int id, GeoCoordinate currentLocation)
        {
            Id = id;
            Latitude = currentLocation.Latitude;
            Longitude = currentLocation.Longitude;
        }
    }
}
