using AutoMapper;
using FoodDeliveryDemo.Vehicles.Dtos;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        private readonly IMapper _objectMapper;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IMapper objectMapper
            )
        {
            _vehicleRepository = vehicleRepository;
            _objectMapper = objectMapper;
        }

        public async Task CreateVehicleAsync(CreateVehicleDto input)
        {
            var vehicleEntity = _objectMapper.Map<Vehicle>(input);
            await _vehicleRepository.InsertAsync(vehicleEntity);
        }
    }
}
