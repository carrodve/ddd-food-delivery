using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleRepository
    {
        Task InsertAsync(Vehicle entity);

        Task<Vehicle> GetByIdAsync(int id);

        //Task UpdateVehicleLocationAsync(int vehicleId, GeoCoordinate newLocation);

        //Task<GeoCoordinate> GetVehicleLocationAsync(int vehicleId);

        //Task AddVehicleLocationHistoryAsync(int vehicleId, GeoCoordinate location);
    }
}
