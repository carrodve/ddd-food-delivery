using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FoodDeliveryDemo
{
    public class VehicleService_Tests : FoodDeliveryDemoTestBase
    {
        private readonly IVehicleService _vehicleService;

        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService_Tests()
        {
            _vehicleService = ServiceProvider.GetService<IVehicleService>();
            _vehicleRepository = ServiceProvider.GetService<IVehicleRepository>();
        }

        [Fact]
        public async Task AddOrderToVehicle()
        {
            //Act

            await _vehicleService.AddOrderAsync(1, Guid.Parse(TestDataBuilder.OrderId3.ToString()));

            var vehicle = await _vehicleRepository.GetByIdAsync(1);

            //Assert

            vehicle.Id.ShouldBe(1);
            vehicle.Orders.Count.ShouldBeGreaterThan(1);
        }

        [Fact]
        public async Task DeleteOrderToVehicle()
        {
            //Act

            await _vehicleService.DeleteOrderAsync(1, Guid.Parse(TestDataBuilder.OrderId1.ToString()));

            var vehicle = await _vehicleRepository.GetByIdAsync(1);

            //Assert

            vehicle.Id.ShouldBe(1);
            vehicle.Orders.Count.ShouldBe(0);
        }

        [Fact]
        public async Task GetCurrentLocationByIdAsync()
        {
            //Act

            var result = await _vehicleService.GetCurrentLocationByIdAsync(2);

            //Assert

            result.Id.ShouldBe(2);
            result.CurrentLocation.ShouldBe(TestDataBuilder.VehicleCurrentLocation2);
        }

        [Fact]
        public async Task CreateVehicleAsync()
        {
            //Arrange

            var input = new CreateVehicleDto
            {
                Id = TestDataBuilder.VehicleNewId1,
                CurrentLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            //Act

            await _vehicleService.CreateVehicleAsync(input);

            //Assert

            var vehicleEntity = await _vehicleRepository.GetByIdAsync(TestDataBuilder.VehicleNewId1);
            vehicleEntity.Id.ShouldBe(TestDataBuilder.VehicleNewId1);
        }

        [Fact]
        public async Task UpdateCurrentLocationAsync()
        {
            //Arrange

            var input = new UpdateVehicleDto
            {
                CurrentLocation = TestDataBuilder.VehicleCurrentLocation2
            };

            //Act

            var result = await _vehicleService.UpdateCurrentLocationAsync(1, input);

            //Assert

            result.Id.ShouldBe(1);
            result.CurrentLocation.ShouldBe(input.CurrentLocation);

            var updatedVehicle = await _vehicleRepository.GetByIdAsync(1);
            updatedVehicle.Latitude.ShouldBe(input.CurrentLocation.Latitude);
            updatedVehicle.Longitude.ShouldBe(input.CurrentLocation.Longitude);
            updatedVehicle.LocationHistory.ShouldNotBeNull();
            updatedVehicle.LocationHistory.Any().ShouldBeTrue();
        }
    }
}
