using FoodDeliveryDemo.Orders;
using FoodDeliveryDemo.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto input)
        {
            await _orderService.CreateAsync(input);
            return Ok();
        }
    }
}
