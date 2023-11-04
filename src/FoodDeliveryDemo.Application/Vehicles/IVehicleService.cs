using FoodDeliveryDemo.Vehicles.Dtos;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleService
    {
        Task AddOrderAsync(int vehicleId, Guid orderId);

        Task DeleteOrderAsync(int vehicleId, Guid orderId);

        Task<VehicleDto> GetCurrentLocationByIdAsync(int id);

        Task CreateAsync(CreateVehicleDto input);

        Task<VehicleDto> UpdateCurrentLocationAsync(int id, UpdateVehicleDto input);
    }
}
