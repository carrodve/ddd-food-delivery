using AutoMapper;
using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Orders.Dtos;
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

        public async Task CreateAsync(CreateOrderDto input)
        {
            var orderEntity = _objectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(orderEntity);
        }

        public async Task<OrderDto> UpdateAsync(Guid id, UpdateOrderDto input)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            order.DeliveryLocation = (GeoCoordinate)input.DeliveryLocation.Clone();
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
