using FoodDeliveryDemo.Configuration;
using System;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class UpdateOrderDto
    {
        public GeoCoordinate DeliveryLocation { get; set; }
    }
}
