using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    public abstract class FoodDeliveryDemoRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly FoodDeliveryDemoDbContext DbContext;

        protected FoodDeliveryDemoRepositoryBase(FoodDeliveryDemoDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            TEntity entity = await GetByIdAsync(id);
            if (entity == null) return;

            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), id);
            }

            return entity;
        }

        public virtual async Task<TEntity> FindByIdAsync(TPrimaryKey id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }
    }
}
