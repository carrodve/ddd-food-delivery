using GeoCoordinatePortable;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleRepository
    {
        Task UpdateVehicleLocationAsync(int vehicleId, GeoCoordinate newLocation);

        Task<GeoCoordinate> GetVehicleLocationAsync(int vehicleId);

        Task AddVehicleLocationHistoryAsync(int vehicleId, GeoCoordinate location);
    }
}
