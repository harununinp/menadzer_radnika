using API.Dto;
using API.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            var projects = await _projectService.GetProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectCreateDto projectDto)
        {
            await _projectService.CreateProject(projectDto);
            return Ok("Project created successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, ProjectUpdateDto projectDto)
        {
            await _projectService.UpdateProject(id, projectDto);
            return Ok("Project updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
            return Ok("Project deleted successfully");
        }
    }
}
