using FoodDeliveryDemo.Vehicles;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implementa <see cref="IVehicleRepository"/> para EntityFrameworkCore.
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        private readonly FoodDeliveryDemoDbContext _dbContext;

        public VehicleRepository(FoodDeliveryDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Vehicle entity)
        {
            await _dbContext.Set<Vehicle>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Vehicle>().FindAsync(id);
        }
    }
}
