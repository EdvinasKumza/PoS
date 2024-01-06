using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IGenericService<OrderItem> _orderItemService;

    public OrderItemsController(IGenericService<OrderItem> orderItemService)
    {
        _orderItemService = orderItemService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var orders = _orderItemService.GetAll();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var order = _orderItemService.GetById(id);
        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public IActionResult Post(OrderItem order)
    {
        _orderItemService.Create(order);
        return CreatedAtAction(nameof(Get), new { id = order.OrderItemId }, order);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, OrderItem order)
    {
        if (id != order.OrderItemId)
        {
            return BadRequest();
        }

        _orderItemService.Update(order);
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _orderItemService.Delete(id);
        return NoContent();
    }
}