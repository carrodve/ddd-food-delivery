using AutoMapper;
using FoodDeliveryDemo.Orders.Dtos;
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

        public async Task CreateOrderAsync(CreateOrderDto input)
        {
            var orderEntity = _objectMapper.Map<Order>(input);
            await _orderRepository.InsertAsync(orderEntity);
        }
    }
}
