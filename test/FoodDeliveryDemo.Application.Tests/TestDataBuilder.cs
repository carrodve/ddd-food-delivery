using FoodDeliveryDemo.Configuration;
using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Vehicles;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo
{
    public class TestDataBuilder
    {
        public static Guid OrderId1 { get; } = new Guid("12345678-1234-1234-1234-123456789abc");

        public static Guid OrderId2 { get; } = new Guid("87654321-4321-4321-4321-987654321cba");

        public static Guid OrderId3 { get; } = new Guid("34567890-3456-2212-9643-123789123cde");

        public static int VehicleNewId1 { get; } = 1234;

        public static GeoCoordinate OrderDeliveryLocation1 { get; } = new GeoCoordinate(40.7128, -74.0060);

        public static GeoCoordinate OrderDeliveryLocation2 { get; } = new GeoCoordinate(34.0522, -118.2437);

        public static GeoCoordinate OrderDeliveryLocation3 { get; } = new GeoCoordinate(10.000, 18.1234);

        public static GeoCoordinate VehicleCurrentLocation1 { get; } = new GeoCoordinate(48.8566, 2.3522);

        public static GeoCoordinate VehicleCurrentLocation2 { get; } = new GeoCoordinate(-33.8568, 151.2153);

        private readonly IOrderRepository _orderRepository;

        private readonly IVehicleRepository _vehicleRepository;

        public TestDataBuilder(
            IOrderRepository orderRepository,
            IVehicleRepository vehicleRepository)
        {
            _orderRepository = orderRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task BuildAsync()
        {
            await AddOrders();
            await AddVehicles();
        }

        private async Task AddOrders()
        {
            await _orderRepository.InsertAsync(new Order(OrderId1, "customer1", "comments1", OrderDeliveryLocation1, 1));
            await _orderRepository.InsertAsync(new Order(OrderId2, "customer2", "comments2", OrderDeliveryLocation2, 2));
            await _orderRepository.InsertAsync(new Order(OrderId3, "customer3", "comments3", OrderDeliveryLocation3));
        }

        private async Task AddVehicles()
        {
            await _vehicleRepository.InsertAsync(new Vehicle(1, VehicleCurrentLocation1));
            await _vehicleRepository.InsertAsync(new Vehicle(2, VehicleCurrentLocation2));
        }
    }
}
