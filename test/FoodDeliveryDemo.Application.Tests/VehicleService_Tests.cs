﻿using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.History;
using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Data;
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
        public async Task UpdateVehicleAsync()
        {
            var input = new UpdateVehicleDto
            {
                CurrentLocation = TestDataBuilder.VehicleCurrentLocation1
            };

            //Act

            var result = await _vehicleService.UpdateVehicleAsync(1, input);

            //Assert

            result.Id.ShouldBe(1);
            result.CurrentLocation.ShouldBe(input.CurrentLocation);

            var updatedVehicle = await _vehicleRepository.GetByIdAsync(1);
            updatedVehicle.CurrentLocation.ShouldBe(input.CurrentLocation);
            updatedVehicle.LocationHistory.ShouldNotBeNull();
            updatedVehicle.LocationHistory.Any().ShouldBeTrue();
        }
    }
}
