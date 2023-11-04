using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodDeliveryDemo.Controllers
{
    [Route("api/orders")]
    public  class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto input)
        {
            await _orderService.CreateAsync(input);
            return Ok();
        }

        [HttpPost("updateOrder")]
        public async Task<IActionResult> UpdateOrderDeliveryLocationAsync(Guid id, [FromBody] UpdateOrderDeliveryLocationDto input)
        {
            await _orderService.UpdateDeliveryLocationAsync(id, input);
            return Ok();
        }

        [HttpPost("deleteOrder")]
        public async Task<IActionResult> DeleteOrderAsync(Guid id)
        {
            await _orderService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderAndVehicleLocationByIdAsync(Guid id)
        {
            await _orderService.GetOrderAndVehicleLocationByIdAsync(id);
            return Ok();
        }
    }
}
