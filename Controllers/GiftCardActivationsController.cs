using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftCardActivationsController : ControllerBase
{
    private readonly IGenericService<GiftCardActivation> _giftCardActivationService;

    public GiftCardActivationsController(IGenericService<GiftCardActivation> giftCardActivationService)
    {
        _giftCardActivationService = giftCardActivationService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var giftCardActivations = _giftCardActivationService.GetAll();
        return Ok(giftCardActivations);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var giftCardActivation = _giftCardActivationService.GetById(id);
        if (giftCardActivation == null)
        {
            return NotFound();
        }

        return Ok(giftCardActivation);
    }

    [HttpPost]
    public IActionResult Post(GiftCardActivation giftCardActivation)
    {
        _giftCardActivationService.Create(giftCardActivation);
        return CreatedAtAction(nameof(Get), new { id = giftCardActivation.ActivationId }, giftCardActivation);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, GiftCardActivation giftCardActivation)
    {
        if (id != giftCardActivation.ActivationId)
        {
            return BadRequest();
        }

        _giftCardActivationService.Update(giftCardActivation);
        return Ok(giftCardActivation);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _giftCardActivationService.Delete(id);
        return NoContent();
    }
}