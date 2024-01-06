using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryOrderItemsController : ControllerBase
{
    private readonly IGenericService<InventoryOrderItem> _inventoryOrderItemService;

    public InventoryOrderItemsController(IGenericService<InventoryOrderItem> inventoryOrderItemService)
    {
        _inventoryOrderItemService = inventoryOrderItemService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var inventoryOrderItems = _inventoryOrderItemService.GetAll();
        return Ok(inventoryOrderItems);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var inventoryOrderItem = _inventoryOrderItemService.GetById(id);
        if (inventoryOrderItem == null)
        {
            return NotFound();
        }

        return Ok(inventoryOrderItem);
    }

    [HttpPost]
    public IActionResult Post(InventoryOrderItem inventoryOrderItem)
    {
        _inventoryOrderItemService.Create(inventoryOrderItem);
        return CreatedAtAction(nameof(Get), new { id = inventoryOrderItem.OrderItemId }, inventoryOrderItem);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, InventoryOrderItem inventoryOrderItem)
    {
        if (id != inventoryOrderItem.OrderItemId)
        {
            return BadRequest();
        }

        _inventoryOrderItemService.Update(inventoryOrderItem);
        return Ok(inventoryOrderItem);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _inventoryOrderItemService.Delete(id);
        return NoContent();
    }
}