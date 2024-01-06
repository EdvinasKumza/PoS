using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly IGenericService<Discount> _discountService;

    public DiscountsController(IGenericService<Discount> discountService)
    {
        _discountService = discountService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var discounts = _discountService.GetAll();
        return Ok(discounts);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var discount = _discountService.GetById(id);
        if (discount == null)
        {
            return NotFound();
        }

        return Ok(discount);
    }

    [HttpPost]
    public IActionResult Post(Discount discount)
    {
        _discountService.Create(discount);
        return CreatedAtAction(nameof(Get), new { id = discount.DiscountId }, discount);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Discount discount)
    {
        if (id != discount.DiscountId)
        {
            return BadRequest();
        }

        _discountService.Update(discount);
        return Ok(discount);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _discountService.Delete(id);
        return NoContent();
    }
}