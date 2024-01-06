using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftCardsController : ControllerBase
{
    private readonly IGenericService<GiftCard> _giftCardService;

    public GiftCardsController(IGenericService<GiftCard> giftCardService)
    {
        _giftCardService = giftCardService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var giftCards = _giftCardService.GetAll();
        return Ok(giftCards);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var giftCard = _giftCardService.GetById(id);
        if (giftCard == null)
        {
            return NotFound();
        }

        return Ok(giftCard);
    }

    [HttpPost]
    public IActionResult Post(GiftCard giftCard)
    {
        _giftCardService.Create(giftCard);
        return CreatedAtAction(nameof(Get), new { id = giftCard.CardNumber }, giftCard);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, GiftCard giftCard)
    {
        if (id != giftCard.CardNumber)
        {
            return BadRequest();
        }

        _giftCardService.Update(giftCard);
        return Ok(giftCard);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _giftCardService.Delete(id);
        return NoContent();
    }
}