using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Controllers;
using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodDeliveryDemo
{
    public class VehicleController_Tests
    {
        [Fact]
        public async Task CreateVehicleAsync()
        {
            // Arrange

            var vehicleServiceMock = new Mock<IVehicleService>();
            var controller = new VehicleController(vehicleServiceMock.Object);
            var input = new CreateVehicleDto
            {
                Id = 1,
                CurrentLocation = new GeoCoordinate(34.0522, -118.2437)
            };

            // Act

            var result = await controller.CreateVehicleAsync(input);

            // Assert

            Assert.IsType<OkResult>(result);
        }
    }
}