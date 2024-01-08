using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IGenericService<Payment> _paymentGenericService;

    public PaymentController(IGenericService<Payment> paymentGenericService)
    {
        _paymentGenericService = paymentGenericService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var payments = _paymentGenericService.GetAll();
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var payment = _paymentGenericService.GetById(id);
        if (payment == null)
        {
            return NotFound();
        }

        return Ok(payment);
    }

    [HttpPost]
    public IActionResult Post(Payment payment)
    {
        _paymentGenericService.Create(payment);
        return CreatedAtAction(nameof(Get), new { id = payment.PaymentId }, payment);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Payment payment)
    {
        if (id != payment.PaymentId)
        {
            return BadRequest();
        }

        _paymentGenericService.Update(payment);
        return Ok(payment);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _paymentGenericService.Delete(id);
        return NoContent();
    }
}