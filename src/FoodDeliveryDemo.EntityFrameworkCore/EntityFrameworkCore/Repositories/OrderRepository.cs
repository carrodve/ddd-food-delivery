using FoodDeliveryDemo.Domain.Entities;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Implementa <see cref="IOrderRepository"/> para EntityFrameworkCore.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodDeliveryDemoDbContext _dbContext;

        public OrderRepository(FoodDeliveryDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(Order entity)
        {
            await _dbContext.Set<Order>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<Order>().FindAsync(id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Set<Order>().ToListAsync();
        }
    }
}
