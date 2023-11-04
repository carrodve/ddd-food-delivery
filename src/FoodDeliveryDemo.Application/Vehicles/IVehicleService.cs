using FoodDeliveryDemo.Vehicles.Dtos;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleService
    {
        Task CreateVehicleAsync(CreateVehicleDto input);

        Task<VehicleDto> UpdateVehicleAsync(int id, UpdateVehicleDto input);
    }
}
