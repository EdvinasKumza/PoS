using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers;

[ApiController]
[Route("[controller]")]
public class LoyaltyProgramsController : ControllerBase
{
    private readonly IGenericService<LoyaltyProgram> _loyaltyProgramService;

    public LoyaltyProgramsController(IGenericService<LoyaltyProgram> loyaltyProgramService)
    {
        _loyaltyProgramService = loyaltyProgramService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var loyaltyPrograms = _loyaltyProgramService.GetAll();
        return Ok(loyaltyPrograms);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var loyaltyProgram = _loyaltyProgramService.GetById(id);
        if (loyaltyProgram == null)
        {
            return NotFound();
        }

        return Ok(loyaltyProgram);
    }

    [HttpPost]
    public IActionResult Post(LoyaltyProgram loyaltyProgram)
    {
        _loyaltyProgramService.Create(loyaltyProgram);
        return CreatedAtAction(nameof(Get), new { id = loyaltyProgram.LoyaltyProgramId }, loyaltyProgram);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, LoyaltyProgram loyaltyProgram)
    {
        if (id != loyaltyProgram.LoyaltyProgramId)
        {
            return BadRequest();
        }

        _loyaltyProgramService.Update(loyaltyProgram);
        return Ok(loyaltyProgram);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _loyaltyProgramService.Delete(id);
        return NoContent();
    }
}