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
        public Task CreateVehicleAsync([FromBody] CreateVehicleDto input)
        {
            return _vehicleService.CreateAsync(input);
        }
    }
}
