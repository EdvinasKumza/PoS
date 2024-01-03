using Microsoft.AspNetCore.Mvc;
using PoS.Services;
using PoS.Services.GenericServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericService<Product> _productService;

        public ProductsController(IGenericService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
