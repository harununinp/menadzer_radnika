using API.Dto;
using API.Services.WorkerService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkerDto>>> GetWorkers()
        {
            var workers = await _workerService.GetWorkers();
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> GetWorkerById(int id)
        {
            var worker = await _workerService.GetWorkerById(id);
            if (worker == null)
            {
                return NotFound();
            }
            return Ok(worker);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorker(WorkerCreateDto workerDto)
        {
            await _workerService.CreateWorker(workerDto);
            return Ok("Worker created successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorker(int id, WorkerUpdateDto workerDto)
        {
            await _workerService.UpdateWorker(id, workerDto);
            return Ok("Worker updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorker(int id)
        {
            await _workerService.DeleteWorker(id);
            return Ok("Worker deleted successfully");
        }
    }
}
