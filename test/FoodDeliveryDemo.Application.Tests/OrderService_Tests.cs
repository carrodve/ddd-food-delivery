using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using FoodDeliveryDemo.Vehicles;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FoodDeliveryDemo
{
    public class OrderService_Tests : FoodDeliveryDemoTestBase
    {
        private readonly IOrderService _orderService;

        private readonly IOrderRepository _orderRepository;

        private readonly IVehicleRepository _vehicleRepository;

        public OrderService_Tests()
        {
            _orderService = ServiceProvider.GetService<IOrderService>();
            _orderRepository = ServiceProvider.GetService<IOrderRepository>();
            _vehicleRepository = ServiceProvider.GetService<IVehicleRepository>();
        }

        [Fact]
        public async Task CreateOrderAsync()
        {
            //Arrange

            var input = new CreateOrderDto
            {
                VehicleId = 1,
                Customer = "test",
                Comments = "none",
                State = OrderState.Created,
                DeliveryLocation = TestDataBuilder.OrderDeliveryLocation1
            };

            //Act

            await _orderService.CreateOrderAsync(input);

            //Assert

            var orders = await _orderRepository.GetAllAsync();

            var orderEntity = orders.FirstOrDefault(x => x.VehicleId == 1 && x.State == OrderState.Created);

            orderEntity.Id.ShouldNotBe(Guid.Empty);
            orderEntity.Customer.ShouldBe("test");
        }

        [Fact]
        public async Task UpdateOrderAsync()
        {
            var input = new UpdateOrderDto
            {
                DeliveryLocation = new GeoCoordinate(40.7128, -74.0060)
            };

            //Act

            var result = await _orderService.UpdateOrderAsync(TestDataBuilder.OrderId1, input);

            //Assert

            result.Id.ShouldBe(TestDataBuilder.OrderId1);
            result.DeliveryLocation.ShouldBe(input.DeliveryLocation);

            var updatedOrder = await _orderRepository.GetByIdAsync(TestDataBuilder.OrderId1);
            updatedOrder.DeliveryLocation.ShouldBe(input.DeliveryLocation);
        }
    }
}