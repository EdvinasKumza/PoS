using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentMethodsController : ControllerBase
{
    private readonly IGenericService<PaymentMethod> _paymentMethodService;

    public PaymentMethodsController(IGenericService<PaymentMethod> paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var paymentMethods = _paymentMethodService.GetAll();
        return Ok(paymentMethods);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var paymentMethod = _paymentMethodService.GetById(id);
        if (paymentMethod == null)
        {
            return NotFound();
        }

        return Ok(paymentMethod);
    }

    [HttpPost]
    public IActionResult Post(PaymentMethod paymentMethod)
    {
        _paymentMethodService.Create(paymentMethod);
        return CreatedAtAction(nameof(Get), new { id = paymentMethod.PaymentMethodId }, paymentMethod);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, PaymentMethod paymentMethod)
    {
        if (id != paymentMethod.PaymentMethodId)
        {
            return BadRequest();
        }

        _paymentMethodService.Update(paymentMethod);
        return Ok(paymentMethod);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _paymentMethodService.Delete(id);
        return NoContent();
    }
}