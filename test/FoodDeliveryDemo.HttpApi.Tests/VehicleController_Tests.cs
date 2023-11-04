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

        [Fact]
        public async Task UpdateCurrentLocationAsync()
        {
            // Arrange

            var vehicleServiceMock = new Mock<IVehicleService>();
            var controller = new VehicleController(vehicleServiceMock.Object);
            var input = new UpdateVehicleDto
            {
                CurrentLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            // Act

            var result = await controller.UpdateCurrentLocationAsync(1, input);

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task AddOrderAsync()
        {
            // Arrange

            var vehicleServiceMock = new Mock<IVehicleService>();
            var controller = new VehicleController(vehicleServiceMock.Object);

            // Act

            var result = await controller.AddOrderAsync(1, Guid.NewGuid());

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteOrderAsync()
        {
            // Arrange

            var vehicleServiceMock = new Mock<IVehicleService>();
            var controller = new VehicleController(vehicleServiceMock.Object);

            // Act

            var result = await controller.DeleteOrderAsync(1, Guid.NewGuid());

            // Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetCurrentLocationByIdAsync()
        {
            // Arrange

            var vehicleServiceMock = new Mock<IVehicleService>();
            var controller = new VehicleController(vehicleServiceMock.Object);

            // Act

            var result = await controller.GetCurrentLocationByIdAsync(1);

            // Assert

            Assert.IsType<OkResult>(result);
        }
    }
}