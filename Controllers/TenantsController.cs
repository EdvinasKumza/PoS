using Microsoft.AspNetCore.Mvc;
using PoS.Services.TenantServices;
using PoS.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using PoS.Services.GenericServices;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly IGenericService<Tenant> _tenantService;

        public TenantsController(IGenericService<Tenant> tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tenants = _tenantService.GetAll();
            return Ok(tenants);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var tenant = _tenantService.GetById(id);
            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        [HttpPost]
        public IActionResult Post(Tenant tenant)
        {
            _tenantService.Create(tenant);
            return CreatedAtAction(nameof(Get), new { id = tenant.TenantId }, tenant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Tenant tenant)
        {
            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            _tenantService.Update(tenant);
            return Ok(tenant);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _tenantService.Delete(id);
            return NoContent();
        }
    }
}
