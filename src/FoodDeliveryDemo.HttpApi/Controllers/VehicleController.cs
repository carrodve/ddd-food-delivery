using FoodDeliveryDemo.Vehicles;
using FoodDeliveryDemo.Vehicles.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] CreateVehicleDto input)
        {
            await _vehicleService.CreateAsync(input);
            return Ok();
        }
    }
}
