using FoodDeliveryDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    public abstract class FoodDeliveryDemoRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly FoodDeliveryDemoDbContext _dbContext;

        protected FoodDeliveryDemoRepositoryBase(FoodDeliveryDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity == null) return;

            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
    }
}
