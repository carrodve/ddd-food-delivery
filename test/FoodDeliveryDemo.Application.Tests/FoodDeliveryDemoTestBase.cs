using AutoMapper;
using FoodDeliveryDemo.EntityFrameworkCore;
using FoodDeliveryDemo.EntityFrameworkCore.Repositories;
using FoodDeliveryDemo.History;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;
using System;

namespace FoodDeliveryDemo
{
    public abstract class FoodDeliveryDemoTestBase
    {
        protected IServiceProvider ServiceProvider { get; }

        protected FoodDeliveryDemoTestBase()
        {
            var services = CreateServiceCollection();
            services.AddEntityFrameworkInMemoryDatabase();

            ConfigureServices(services);

            ServiceProvider = CreateServiceProvider(services);

            SeedTestData();
        }

        protected virtual IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        protected virtual IServiceProvider CreateServiceProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderMapProfile());
                mc.AddProfile(new VehicleMapProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var builder = new DbContextOptionsBuilder<FoodDeliveryDemoDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            services.AddScoped(_ => new FoodDeliveryDemoDbContext(options));
            services.AddScoped<TestDataBuilder>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleLocationHistoryRepository, VehicleLocationHistoryRepository>();
        }

        private void SeedTestData()
        {
            AsyncContext.Run(() => ServiceProvider
                .GetRequiredService<TestDataBuilder>()
                .BuildAsync());
        }
    }
}
