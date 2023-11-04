using AutoMapper;
using FoodDeliveryDemo.Exceptions;
using FoodDeliveryDemo.Orders.Dtos;
using FoodDeliveryDemo.Vehicles.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IMapper _objectMapper;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper objectMapper)
        {
            _orderRepository = orderRepository;
            _objectMapper = objectMapper;
        }

        public async Task<GetOrderAndVehicleLocationDto> GetOrderAndVehicleLocationByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), id);
            }

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

        public async Task CreateAsync(CreateOrderDto input)
        {
            var orderEntity = _objectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(orderEntity);
        }

        public async Task<OrderDto> UpdateDeliveryLocationAsync(Guid id, UpdateOrderDeliveryLocationDto input)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                throw new EntityNotFoundException(nameof(Order), id);
            }

            order.Latitude = input.DeliveryLocation.Latitude;
            order.Longitude = input.DeliveryLocation.Longitude;
            order.ModificationTime = DateTime.Now;

            await _orderRepository.UpdateAsync(order);

            return _objectMapper.Map<Order, OrderDto>(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
