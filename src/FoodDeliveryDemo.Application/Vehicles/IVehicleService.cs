using FoodDeliveryDemo.Vehicles.Dtos;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleService
    {
        Task<VehicleDto> GetAsync(int id);

        Task CreateAsync(CreateVehicleDto input);

        Task<VehicleDto> UpdateAsync(int id, UpdateVehicleDto input);
    }
}
