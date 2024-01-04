
using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IGenericService<Order> _orderService;

        public OrdersController(IGenericService<Order> orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            _orderService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _orderService.Update(order);
            return Ok(order);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _orderService.Delete(id);
            return NoContent();
        }
    }
}