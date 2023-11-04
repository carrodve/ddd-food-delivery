using AutoMapper;
using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Orders.Dtos;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles.Dtos;
using System.Threading.Tasks;
using System;
using FoodDeliveryDemo.History;

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

        public async Task CreateVehicleAsync(CreateVehicleDto input)
        {
            var vehicleEntity = _objectMapper.Map<Vehicle>(input);
            await _vehicleRepository.InsertAsync(vehicleEntity);
        }

        public async Task<VehicleDto> UpdateVehicleAsync(int id, UpdateVehicleDto input)
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
