using System;

namespace FoodDeliveryDemo.Orders.Dtos
{
    public class OrderDto : CreateOrderDto
    {
        public Guid Id { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}
