using AutoMapper;
using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.History;
using FoodDeliveryDemo.Vehicles.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        private readonly IVehicleLocationHistoryRepository _vehicleLocationHistoryRepository;

        private readonly IMapper _objectMapper;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleLocationHistoryRepository vehicleLocationHistoryRepository,
            IMapper objectMapper
            )
        {
            _vehicleRepository = vehicleRepository;
            _vehicleLocationHistoryRepository = vehicleLocationHistoryRepository;
            _objectMapper = objectMapper;
        }

        public async Task<VehicleDto> GetAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            return _objectMapper.Map<Vehicle, VehicleDto>(vehicle);
        }

        public async Task CreateAsync(CreateVehicleDto input)
        {
            var vehicleEntity = _objectMapper.Map<Vehicle>(input);
            await _vehicleRepository.InsertAsync(vehicleEntity);
        }

        public async Task<VehicleDto> UpdateAsync(int id, UpdateVehicleDto input)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);

            var history = new VehicleLocationHistory();
            history.Location = (GeoCoordinate)vehicle.CurrentLocation.Clone();
            history.VehicleId = vehicle.Id;

            await _vehicleLocationHistoryRepository.InsertAsync(history);

            vehicle.CurrentLocation = (GeoCoordinate)input.CurrentLocation.Clone();
            vehicle.ModificationTime = DateTime.Now;

            await _vehicleRepository.UpdateAsync(vehicle);

            return _objectMapper.Map<Vehicle, VehicleDto>(vehicle);
        }
    }
}
