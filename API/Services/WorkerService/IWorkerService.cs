using API.Dto;

namespace API.Services.WorkerService
{
    public interface IWorkerService
    {
        Task<List<WorkerDto>> GetWorkers();
        Task<WorkerDto> GetWorkerById(int id);
        Task<ServiceResponseDto> CreateWorker(WorkerCreateDto workerDto);
        Task<ServiceResponseDto> UpdateWorker(int workerId, WorkerUpdateDto workerDto);
        Task<ServiceResponseDto> DeleteWorker(int id);
    }
}
