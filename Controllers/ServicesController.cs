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
    public class ServicesController : ControllerBase
    {
        private readonly IGenericService<Service> _serviceService;

        public ServicesController(IGenericService<Service> serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var services = _serviceService.GetAll();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var service = _serviceService.GetById(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public IActionResult Post(Service service)
        {
            _serviceService.Create(service);
            return CreatedAtAction(nameof(Get), new { id = service.ServiceId }, service);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Service service)
        {
            if (id != service.ServiceId)
            {
                return BadRequest();
            }

            _serviceService.Update(service);
            return Ok(service);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _serviceService.Delete(id);
            return NoContent();
        }
    }
}
