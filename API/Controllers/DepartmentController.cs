using API.Dto;
using API.Services.DepartmentService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment(DepartmentCreateDto departmentDto)
        {
            await _departmentService.CreateDepartment(departmentDto);
            return Ok("Department created successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, DepartmentUpdateDto departmentDto)
        {
            await _departmentService.UpdateDepartment(id, departmentDto);
            return Ok("Department updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok("Department deleted successfully");
        }
    }
}
