using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Controllers
{
    [Route("api/vehicles")]
    public  class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(
            IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("createVehicle")]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] CreateVehicleDto input)
        {
            await _vehicleService.CreateVehicleAsync(input);
            return Ok();
        }

        [HttpPost("updateVehicle")]
        public async Task<IActionResult> UpdateCurrentLocationAsync(int id, [FromBody] UpdateVehicleDto input)
        {
            await _vehicleService.UpdateCurrentLocationAsync(id, input);
            return Ok();
        }

        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrderAsync(int id, Guid orderId)
        {
            await _vehicleService.AddOrderAsync(id, orderId);
            return Ok();
        }

        [HttpPost("deleteOrder")]
        public async Task<IActionResult> DeleteOrderAsync(int id, Guid orderId)
        {
            await _vehicleService.DeleteOrderAsync(id, orderId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentLocationByIdAsync(int id)
        {
            await _vehicleService.GetCurrentLocationByIdAsync(id);
            return Ok();
        }
    }
}
