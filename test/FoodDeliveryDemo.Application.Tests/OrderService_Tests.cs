using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using FoodDeliveryDemo.Vehicles;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FoodDeliveryDemo
{
    public class OrderService_Tests : FoodDeliveryDemoTestBase
    {
        private readonly IOrderService _orderService;

        private readonly IOrderRepository _orderRepository;

        private readonly IVehicleRepository _vehicleRepository;

        public OrderService_Tests()
        {
            _orderService = ServiceProvider.GetService<IOrderService>();
            _orderRepository = ServiceProvider.GetService<IOrderRepository>();
            _vehicleRepository = ServiceProvider.GetService<IVehicleRepository>();
        }

        [Fact]
        public async Task CreateAsync()
        {
            //Arrange
            await _vehicleRepository.InsertAsync(new Vehicle() { Id = 1 });

            var input = new CreateOrderDto
            {
                VehicleId = 1,
                Customer = "test",
                Comments = "none",
                State = OrderState.Created,
                DeliveryLocation = new GeoCoordinate(37.7749, -122.4194)
            };

            //Act

            await _orderService.CreateOrderAsync(input);

            //Assert

            var orders = await _orderRepository.GetAllAsync();

            var orderEntity = orders.FirstOrDefault();

            orderEntity.Id.ShouldNotBe(Guid.Empty);
            orderEntity.Customer.ShouldBe("test");
        }
    }
}