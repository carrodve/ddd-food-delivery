using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Controllers;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodDeliveryDemo
{
    public class OrderController_Tests
    {
        [Fact]
        public async Task CreateOrderAsync()
        {
            // Arrange

            var orderServiceMock = new Mock<IOrderService>();
            var controller = new OrderController(orderServiceMock.Object);
            var input = new CreateOrderDto
            {
                VehicleId = 1,
                Customer = "test",
                Comments = "none",
                State = OrderState.Created,
                DeliveryLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            // Act

            var result = await controller.CreateOrderAsync(input);

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateOrderDeliveryLocationAsync()
        {
            // Arrange

            var orderServiceMock = new Mock<IOrderService>();
            var controller = new OrderController(orderServiceMock.Object);
            var input = new UpdateOrderDeliveryLocationDto
            {
                DeliveryLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            // Act

            var result = await controller.UpdateOrderDeliveryLocationAsync(Guid.NewGuid(), input);

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteOrderAsync()
        {
            // Arrange

            var orderServiceMock = new Mock<IOrderService>();
            var controller = new OrderController(orderServiceMock.Object);

            // Act

            var result = await controller.DeleteOrderAsync(Guid.NewGuid());

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetOrderAndVehicleLocationByIdAsync()
        {
            // Arrange

            var orderServiceMock = new Mock<IOrderService>();
            var controller = new OrderController(orderServiceMock.Object);

            // Act

            var result = await controller.GetOrderAndVehicleLocationByIdAsync(Guid.NewGuid());

            // Assert

            Assert.IsType<OkResult>(result);
        }
    }
}