using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Controllers;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodDeliveryDemo
{
    public class OrderControllerTests
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
    }
}