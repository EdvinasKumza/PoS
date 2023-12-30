using Microsoft.AspNetCore.Mvc;
using PoS.Services;
using WebApplication1.Models;

namespace PoS.Controllers
{
    /*[ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = _workerService.GetAllWorkers();
            return Ok(workers);
        }

        [HttpPost]
        public IActionResult CreateWorker([FromBody] Worker worker)
        {
            _workerService.CreateWorker(worker);
            return CreatedAtAction(nameof(GetWorkerById), new { id = worker.WorkerId }, worker);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkerById(string id)
        {
            var worker = _workerService.GetWorkerById(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorker(string id, [FromBody] Worker worker)
        {
            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            _workerService.UpdateWorker(worker);
            return Ok(worker);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorker(string id)
        {
            _workerService.DeleteWorker(id);
            return NoContent();
        }
    }*/

    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = _workerService.GetAll();
            return Ok(workers);
        }

        [HttpPost]
        public IActionResult CreateWorker([FromBody] Worker worker)
        {
            _workerService.Create(worker);
            return CreatedAtAction(nameof(GetWorkerById), new { id = worker.WorkerId }, worker);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkerById(string id)
        {
            var worker = _workerService.GetById(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorker(string id, [FromBody] Worker worker)
        {
            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            _workerService.Update(worker);
            return Ok(worker);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorker(string id)
        {
            _workerService.Delete(id);
            return NoContent();
        }
    }
}
