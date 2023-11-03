using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.History;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<VehicleLocationHistory> LocationHistory { get; set; }
    }
}
