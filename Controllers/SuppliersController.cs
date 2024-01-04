
using Microsoft.AspNetCore.Mvc;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly IGenericService<Supplier> _supplierService;

        public SuppliersController(IGenericService<Supplier> supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var suppliers = _supplierService.GetAll();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var supplier = _supplierService.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult Post(Supplier supplier)
        {
            _supplierService.Create(supplier);
            return CreatedAtAction(nameof(Get), new { id = supplier.SupplierId }, supplier);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(string id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return BadRequest();
            }

            _supplierService.Update(supplier);
            return Ok(supplier);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _supplierService.Delete(id);
            return NoContent();
        }
    }
}