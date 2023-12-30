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
    public class RolesController : ControllerBase
    {
        private readonly IGenericService<Role> _roleService;

        public RolesController(IGenericService<Role> roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleService.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var role = _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post(Role role)
        {
            _roleService.Create(role);
            return CreatedAtAction(nameof(Get), new { id = role.RoleId }, role);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            _roleService.Update(role);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _roleService.Delete(id);
            return NoContent();
        }
    }
}
