using API.Database;
using API.Dto;
using API.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services.DepartmentService
{
    public class DepartmentService(DataContext context) : IDepartmentService
    {
        public async Task<List<DepartmentDto>> GetDepartments()
        {
            var departments = await context.Departments.ToListAsync();
            return departments.Adapt<List<DepartmentDto>>();
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var department = await context.Departments.FindAsync(id);
            return department.Adapt<DepartmentDto>();
        }

        public async Task<ServiceResponseDto> CreateDepartment(DepartmentCreateDto departmentDto)
        {
            var department = departmentDto.Adapt<Department>();
            context.Departments.Add(department);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = department, ISuccess = true, Message = "Department created successfully" };
        }

        public async Task<ServiceResponseDto> UpdateDepartment(int departmentId, DepartmentUpdateDto departmentDto)
        {
            var department = await context.Departments.FindAsync(departmentId);
            if (department == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Department not found" };
            }

            departmentDto.Adapt(department);
            context.Departments.Update(department);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = department, ISuccess = true, Message = "Department updated successfully" };
        }

        public async Task<ServiceResponseDto> DeleteDepartment(int id)
        {
            var department = await context.Departments.FindAsync(id);
            if (department == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Department not found" };
            }

            context.Departments.Remove(department);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { ISuccess = true, Message = "Department deleted successfully" };
        }
    }
}
