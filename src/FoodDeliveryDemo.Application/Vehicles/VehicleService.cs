using AutoMapper;
using FoodDeliveryDemo.History;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public class VehicleService : FoodDeliveryDemoServiceBase, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        private readonly IVehicleLocationHistoryRepository _vehicleLocationHistoryRepository;

        private readonly IOrderRepository _orderRepository;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleLocationHistoryRepository vehicleLocationHistoryRepository,
            IOrderRepository orderRepository,
            IMapper objectMapper)
            : base(objectMapper)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleLocationHistoryRepository = vehicleLocationHistoryRepository;
            _orderRepository = orderRepository;
        }

        public async Task<VehicleDto> GetCurrentLocationByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            return ObjectMapper.Map<Vehicle, VehicleDto>(vehicle);
        }

        public async Task AddOrderAsync(int vehicleId, Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            await UpdateVehicleOrdersAsync(vehicleId, vehicle =>
            {
                if (!vehicle.Orders.Any(o => o.Id == orderId))
                {
                    vehicle.Orders.Add(order);
                }
            });
        }

        public async Task DeleteOrderAsync(int vehicleId, Guid orderId)
        {
            await UpdateVehicleOrdersAsync(vehicleId, vehicle =>
            {
                var orderToRemove = vehicle.Orders.FirstOrDefault(o => o.Id == orderId);
                if (orderToRemove != null)
                {
                    vehicle.Orders.Remove(orderToRemove);
                }
            });
        }

        public async Task CreateVehicleAsync(CreateVehicleDto input)
        {
            var vehicleEntity = ObjectMapper.Map<Vehicle>(input);
            await _vehicleRepository.InsertAsync(vehicleEntity);
        }

        public async Task<VehicleDto> UpdateCurrentLocationAsync(int id, UpdateVehicleDto input)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);

            await _vehicleLocationHistoryRepository.InsertAsync(new VehicleLocationHistory()
            {
                VehicleId = vehicle.Id,
                Latitude = vehicle.Latitude,
                Longitude = vehicle.Longitude
            });

            vehicle.Latitude = input.CurrentLocation.Latitude;
            vehicle.Longitude = input.CurrentLocation.Longitude;
            vehicle.ModificationTime = DateTime.Now;

            await _vehicleRepository.UpdateAsync(vehicle);

            return ObjectMapper.Map<Vehicle, VehicleDto>(vehicle);
        }

        private async Task UpdateVehicleOrdersAsync(int vehicleId, Action<Vehicle> updateAction)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(vehicleId);

            if (vehicle.Orders == null)
            {
                return;
            }

            updateAction(vehicle);
        }
    }
}
