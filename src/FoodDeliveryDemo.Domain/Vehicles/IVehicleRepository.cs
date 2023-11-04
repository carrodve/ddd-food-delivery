using System.Threading.Tasks;

namespace FoodDeliveryDemo.Vehicles
{
    public interface IVehicleRepository
    {
        Task InsertAsync(Vehicle entity);

        Task UpdateAsync(Vehicle entity);

        Task<Vehicle> GetByIdAsync(int id);
    }
}
