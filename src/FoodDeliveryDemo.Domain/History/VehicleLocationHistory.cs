using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.Vehicles;
using System;

namespace FoodDeliveryDemo.History
{
    /// <summary>
    /// Entidad histórico de vehiculos que representa el historial de localizaciones
    /// </summary>
    public class VehicleLocationHistory : Entity<int>
    {
        /// <summary>
        /// Localización
        /// </summary>
        public GeoCoordinate Location { get; set; }

        /// <summary>
        /// Representa la relación 1:N con vehiculo
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Objeto de la relación
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreationTime { get; set; }

        public VehicleLocationHistory()
        {
            CreationTime = DateTime.Now;
        }
    }
}
