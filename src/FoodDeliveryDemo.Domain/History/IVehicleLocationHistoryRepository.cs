using System.Threading.Tasks;

namespace FoodDeliveryDemo.History
{
    public interface IVehicleLocationHistoryRepository
    {
        Task InsertAsync(VehicleLocationHistory entity);
    }
}
