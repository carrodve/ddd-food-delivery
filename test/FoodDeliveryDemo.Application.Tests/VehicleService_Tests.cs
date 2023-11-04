using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
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
        public async Task CreateAsync()
        {
            //Arrange

            var input = new CreateVehicleDto
            {
                Id = 1,
                CurrentLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            //Act

            await _vehicleService.CreateVehicleAsync(input);

            //Assert

            var vehicleEntity = await _vehicleRepository.GetByIdAsync(1);
            vehicleEntity.Id.ShouldBe(1);
        }
    }
}
