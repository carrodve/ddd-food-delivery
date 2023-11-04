using AutoMapper;
using FoodDeliveryDemo.Orders.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public class OrderService : FoodDeliveryDemoServiceBase, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper objectMapper)
            : base(objectMapper)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderAndVehicleLocationDto> GetOrderAndVehicleLocationByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            
            var output = new GetOrderAndVehicleLocationDto()
            {
                DeliveryLocation = new Configuration.GeoCoordinate(order.Latitude, order.Longitude),
            };

            if (order.Vehicle != null)
            {
                output.CurrentLocation = new Configuration.GeoCoordinate(order.Vehicle.Latitude, order.Vehicle.Longitude);
            }

            return output;
        }

        public async Task CreateOrderAsync(CreateOrderDto input)
        {
            var orderEntity = ObjectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(orderEntity);
        }

        public async Task<OrderDto> UpdateDeliveryLocationAsync(Guid id, UpdateOrderDeliveryLocationDto input)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            order.Latitude = input.DeliveryLocation.Latitude;
            order.Longitude = input.DeliveryLocation.Longitude;
            order.ModificationTime = DateTime.Now;

            await _orderRepository.UpdateAsync(order);

            return ObjectMapper.Map<Order, OrderDto>(order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
