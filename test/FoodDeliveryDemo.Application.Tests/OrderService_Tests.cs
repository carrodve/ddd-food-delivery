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

        public OrderService_Tests()
        {
            _orderService = ServiceProvider.GetService<IOrderService>();
            _orderRepository = ServiceProvider.GetService<IOrderRepository>();
        }

        [Fact]
        public async Task GetOrderAndVehicleLocationByIdAsync()
        {
            //Act

            var result = await _orderService.GetOrderAndVehicleLocationByIdAsync(TestDataBuilder.OrderId1);

            //Assert

            result.DeliveryLocation.ShouldNotBeNull();
            result.CurrentLocation.ShouldNotBeNull();
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

            await _orderService.CreateAsync(input);

            //Assert

            var orders = await _orderRepository.GetAllListAsync();

            var orderEntity = orders.FirstOrDefault(x => x.VehicleId == 1 && x.State == OrderState.Created && x.Customer == "test");

            orderEntity.Id.ShouldNotBe(Guid.Empty);
            orderEntity.Customer.ShouldBe("test");
        }

        [Fact]
        public async Task UpdateOrderAsync()
        {
            var input = new UpdateOrderDeliveryLocationDto
            {
                DeliveryLocation = TestDataBuilder.OrderDeliveryLocation2
            };

            //Act

            var result = await _orderService.UpdateDeliveryLocationAsync(TestDataBuilder.OrderId1, input);

            //Assert

            result.Id.ShouldBe(TestDataBuilder.OrderId1);
            result.DeliveryLocation.ShouldBe(input.DeliveryLocation);

            var updatedOrder = await _orderRepository.GetByIdAsync(TestDataBuilder.OrderId1);
            updatedOrder.Latitude.ShouldBe(input.DeliveryLocation.Latitude);
            updatedOrder.Longitude.ShouldBe(input.DeliveryLocation.Longitude);
        }

        [Fact]
        public async Task DeleteOrderAsync()
        {
            //Arrange

            var deletedOrder = await _orderRepository.GetByIdAsync(TestDataBuilder.OrderId1);

            //Act

            await _orderService.DeleteAsync(deletedOrder.Id);

            //Assert

            var findOrder = await _orderRepository.GetByIdAsync(TestDataBuilder.OrderId1);
            findOrder.ShouldBeNull();
        }
    }
}