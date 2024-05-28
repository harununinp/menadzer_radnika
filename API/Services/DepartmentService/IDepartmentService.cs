using API.Dto;

namespace API.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<ServiceResponseDto> CreateDepartment(DepartmentCreateDto departmentDto);
        Task<ServiceResponseDto> UpdateDepartment(int departmentId, DepartmentUpdateDto departmentDto);
        Task<ServiceResponseDto> DeleteDepartment(int id);
    }
}
