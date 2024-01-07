
using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using PoS.Services.OrderServices;
using PoS.Dtos.Order;
using WebApplication1.Models;
using PoS.Dtos.OrderItem;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IGenericService<Order> _orderGenericService;

        public OrdersController(IOrderService orderService, IGenericService<Order> orderGenericService)
        {
            _orderService = orderService;
            _orderGenericService = orderGenericService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderGenericService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var order = _orderGenericService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var order = _orderService.Create(createOrderDto);
                return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _orderGenericService.Update(order);
            return Ok(order);
        }

        [HttpPost("{orderId}/items")]
        public IActionResult AddItem(string orderId, [FromBody] OrderItemDto addItemDto)
        {
            try
            {
                _orderService.AddItemToOrder(orderId, addItemDto);
                return Ok("Item added to order successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{orderId}/items/{orderItemId}")]
        public IActionResult RemoveItem(string orderId, string orderItemId)
        {
            try
            {
                _orderService.RemoveItemFromOrder(orderId, orderItemId);
                return Ok("Item removed from order successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _orderGenericService.Delete(id);
            return NoContent();
        }
    }
}