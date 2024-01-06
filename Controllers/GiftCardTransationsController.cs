using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftCardTransationsController : ControllerBase
{
    private readonly IGenericService<GiftCardTransaction> _giftCardTransactionService;

    public GiftCardTransationsController(IGenericService<GiftCardTransaction> giftCardTransactionService)
    {
        _giftCardTransactionService = giftCardTransactionService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var giftCardTransactions = _giftCardTransactionService.GetAll();
        return Ok(giftCardTransactions);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var giftCardTransaction = _giftCardTransactionService.GetById(id);
        if (giftCardTransaction == null)
        {
            return NotFound();
        }

        return Ok(giftCardTransaction);
    }

    [HttpPost]
    public IActionResult Post(GiftCardTransaction giftCardTransaction)
    {
        _giftCardTransactionService.Create(giftCardTransaction);
        return CreatedAtAction(nameof(Get), new { id = giftCardTransaction.TransactionId }, giftCardTransaction);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, GiftCardTransaction giftCardTransaction)
    {
        if (id != giftCardTransaction.TransactionId)
        {
            return BadRequest();
        }

        _giftCardTransactionService.Update(giftCardTransaction);
        return Ok(giftCardTransaction);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _giftCardTransactionService.Delete(id);
        return NoContent();
    }
}