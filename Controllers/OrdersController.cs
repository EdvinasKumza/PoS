
using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using PoS.Services.OrderServices;
using PoS.Dtos.Order;
using PoS.Dtos.Payment;
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
                var order = _orderService.AddItemToOrder(orderId, addItemDto);
                return Ok(order);
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
                var order = _orderService.RemoveItemFromOrder(orderId, orderItemId);
                return Ok(order);
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
        [HttpPost("{orderId}/applyDiscount/{discountId}")]
        public IActionResult ApplyDiscount(string orderId, string discountId)
        {
            try
            {
                var order = _orderService.ApplyDiscount(orderId, discountId);
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{orderId}/applyLoyaltyProgram/{loyaltyProgramId}")]
        public IActionResult ApplyLoyaltyProgram(string orderId, string loyaltyProgramId)
        {
            try
            {
                var order = _orderService.ApplyLoyaltyProgram(orderId, loyaltyProgramId);
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{orderId}/addTip")]
        public IActionResult AddTip(string orderId, [FromBody] decimal tipAmount)
        {
            try
            {
                var order = _orderService.AddTip(orderId, tipAmount);
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{orderId}/pay")]
        public IActionResult ProcessPayment(string orderId, [FromBody] CreatePaymentDto createPaymentDto)
        {
            try
            {
                var order = _orderService.ProcessPayment(orderId, createPaymentDto);
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}/receipt")]
        public IActionResult GetReceipt(string orderId)
        {
            try
            {
                var orderReceipt = _orderService.GetReceipt(orderId);
                return Ok(orderReceipt);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}