using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerLoyaltiesController : ControllerBase
{
    private readonly IGenericService<CustomerLoyalty> _customerLoyaltyService;

    public CustomerLoyaltiesController(IGenericService<CustomerLoyalty> customerLoyaltyService)
    {
        _customerLoyaltyService = customerLoyaltyService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var customerLoyalties = _customerLoyaltyService.GetAll();
        return Ok(customerLoyalties);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var customerLoyalty = _customerLoyaltyService.GetById(id);
        if (customerLoyalty == null)
        {
            return NotFound();
        }

        return Ok(customerLoyalty);
    }

    [HttpPost]
    public IActionResult Post(CustomerLoyalty customerLoyalty)
    {
        _customerLoyaltyService.Create(customerLoyalty);
        return CreatedAtAction(nameof(Get), new { id = customerLoyalty.CustomerLoyaltyId }, customerLoyalty);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, CustomerLoyalty customerLoyalty)
    {
        if (id != customerLoyalty.CustomerLoyaltyId)
        {
            return BadRequest();
        }

        _customerLoyaltyService.Update(customerLoyalty);
        return Ok(customerLoyalty);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _customerLoyaltyService.Delete(id);
        return NoContent();
    }
}