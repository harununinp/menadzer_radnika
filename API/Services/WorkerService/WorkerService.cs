using API.Database;
using API.Dto;
using API.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services.WorkerService
{
    public class WorkerService(DataContext context) : IWorkerService
    {
        public async Task<List<WorkerDto>> GetWorkers()
        {
            var workers = await context.Workers.ToListAsync();
            return workers.Adapt<List<WorkerDto>>();
        }

        public async Task<WorkerDto> GetWorkerById(int id)
        {
            var worker = await context.Workers.FindAsync(id);
            return worker.Adapt<WorkerDto>();
        }

        public async Task<ServiceResponseDto> CreateWorker(WorkerCreateDto workerDto)
        {
            var worker = workerDto.Adapt<Worker>();
            context.Workers.Add(worker);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = worker, ISuccess = true, Message = "Worker created successfully" };
        }

        public async Task<ServiceResponseDto> UpdateWorker(int workerId, WorkerUpdateDto workerDto)
        {
            var worker = await context.Workers.FindAsync(workerId);
            if (worker == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Worker not found" };
            }

            workerDto.Adapt(worker);
            context.Workers.Update(worker);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = worker, ISuccess = true, Message = "Worker updated successfully" };
        }

        public async Task<ServiceResponseDto> DeleteWorker(int id)
        {
            var worker = await context.Workers.FindAsync(id);
            if (worker == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Worker not found" };
            }

            context.Workers.Remove(worker);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { ISuccess = true, Message = "Worker deleted successfully" };
        }
    }
}
