using FoodDeliveryDemo.History;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implementa <see cref="VehicleLocationHistoryRepository"/> para EntityFrameworkCore.
    /// </summary>
    public class VehicleLocationHistoryRepository : FoodDeliveryDemoRepositoryBase<VehicleLocationHistory, int>, IVehicleLocationHistoryRepository
    {
        public VehicleLocationHistoryRepository(FoodDeliveryDemoDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
