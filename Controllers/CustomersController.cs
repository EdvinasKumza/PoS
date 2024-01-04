using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IGenericService<Customer> _customerService;

    public CustomersController(IGenericService<Customer> customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var customers = _customerService.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var customer = _customerService.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Post(Customer customer)
    {
        _customerService.Create(customer);
        return CreatedAtAction(nameof(Get), new { id = customer.CustomerID }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Customer customer)
    {
        if (id != customer.CustomerID)
        {
            return BadRequest();
        }

        _customerService.Update(customer);
        return Ok(customer);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _customerService.Delete(id);
        return NoContent();
    }
}