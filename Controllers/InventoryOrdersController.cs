using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryOrderController : ControllerBase
{
    private readonly IGenericService<InventoryOrder> _inventoryOrderService;

    public InventoryOrderController(IGenericService<InventoryOrder> inventoryOrderService)
    {
        _inventoryOrderService = inventoryOrderService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var inventoryOrders = _inventoryOrderService.GetAll();
        return Ok(inventoryOrders);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var inventoryOrder = _inventoryOrderService.GetById(id);
        if (inventoryOrder == null)
        {
            return NotFound();
        }

        return Ok(inventoryOrder);
    }

    [HttpPost]
    public IActionResult Post(InventoryOrder inventoryOrder)
    {
        _inventoryOrderService.Create(inventoryOrder);
        return CreatedAtAction(nameof(Get), new { id = inventoryOrder.OrderId }, inventoryOrder);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, InventoryOrder inventoryOrder)
    {
        if (id != inventoryOrder.OrderId)
        {
            return BadRequest();
        }

        _inventoryOrderService.Update(inventoryOrder);
        return Ok(inventoryOrder);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _inventoryOrderService.Delete(id);
        return NoContent();
    }
}