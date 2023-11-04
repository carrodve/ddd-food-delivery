using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.Vehicles;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryDemo.Orders
{
    /// <summary>
    /// Entidad pedido auditable con identificador único y relacionada con vehículos.
    /// </summary>
    public class Order : AuditableEntity
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [StringLength(OrderConsts.MaxCustomerLength)]
        public string Customer { get; set; }

        /// <summary>
        /// Observaciones
        /// </summary>
        [StringLength(OrderConsts.MaxCommentsLength)]
        public string Comments { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        public OrderState State { get; set; }

        /// <summary>
        /// Posición del pedido que representa la ubicación de entrega
        /// </summary>
        public GeoCoordinate DeliveryLocation { get; set; }

        /// <summary>
        /// Representa la relación 1:N con vehiculo
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Objeto de la relación
        /// </summary>
        public Vehicle Vehicle { get; set; }
    }
}
