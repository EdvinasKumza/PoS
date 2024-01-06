using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IGenericService<Payment> _paymentService;

    public PaymentController(IGenericService<Payment> paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var payments = _paymentService.GetAll();
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var payment = _paymentService.GetById(id);
        if (payment == null)
        {
            return NotFound();
        }

        return Ok(payment);
    }

    [HttpPost]
    public IActionResult Post(Payment payment)
    {
        _paymentService.Create(payment);
        return CreatedAtAction(nameof(Get), new { id = payment.PaymentId }, payment);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, Payment payment)
    {
        if (id != payment.PaymentId)
        {
            return BadRequest();
        }

        _paymentService.Update(payment);
        return Ok(payment);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _paymentService.Delete(id);
        return NoContent();
    }
}