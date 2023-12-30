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
    public class PermissionsController : ControllerBase
    {
        private readonly IGenericService<Permission> _permissionService;

        public PermissionsController(IGenericService<Permission> permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var permissions = _permissionService.GetAll();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var permission = _permissionService.GetById(id);
            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        [HttpPost]
        public IActionResult Post(Permission permission)
        {
            _permissionService.Create(permission);
            return CreatedAtAction(nameof(Get), new { id = permission.PermissionId }, permission);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Permission permission)
        {
            if (id != permission.PermissionId)
            {
                return BadRequest();
            }

            _permissionService.Update(permission);
            return Ok(permission);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _permissionService.Delete(id);
            return NoContent();
        }
    }
}
