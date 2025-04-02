using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTjdeed.DTOs;
using TaskTjdeed.Models;
using TaskTjdeed.Services;

namespace TaskTjdeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        
        [HttpGet("GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _ordersService.GetOrders());
        }

        
        [HttpGet("GetOrderByID/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _ordersService.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        
        [Authorize] // Only authenticated users can place orders
        [HttpPost("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var order = await _ordersService.CreateOrder(orderDto);
            if (order == null) return BadRequest("User not found or invalid products");
            return Ok(order);
        }

        
        [Authorize(Roles = "Admin")] // Only Admins can update orders
        [HttpPut("UpdateOrder/{id}")]
        public async Task<ActionResult<bool>> UpdateOrder(int id, OrderDto orderDto)
        {
            var updated = await _ordersService.UpdateOrder(id, orderDto);
            if (!updated) return BadRequest("Order not found");
            return Ok(true);
        }
    }
}
