using API.Database;
using API.Dto;
using API.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Services.ProjectService
{
    public class ProjectService(DataContext context) : IProjectService
    {
        public async Task<List<ProjectDto>> GetProjects()
        {
            var projects = await context.Projects.ToListAsync();
            return projects.Adapt<List<ProjectDto>>();
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            var project = await context.Projects.FindAsync(id);
            return project.Adapt<ProjectDto>();
        }

        public async Task<ServiceResponseDto> CreateProject(ProjectCreateDto projectDto)
        {
            var project = projectDto.Adapt<Project>();
            context.Projects.Add(project);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = project, ISuccess = true, Message = "Project created successfully" };
        }

        public async Task<ServiceResponseDto> UpdateProject(int projectId, ProjectUpdateDto projectDto)
        {
            var project = await context.Projects.FindAsync(projectId);
            if (project == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Project not found" };
            }

            projectDto.Adapt(project);
            context.Projects.Update(project);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { Data = project, ISuccess = true, Message = "Project updated successfully" };
        }

        public async Task<ServiceResponseDto> DeleteProject(int id)
        {
            var project = await context.Projects.FindAsync(id);
            if (project == null)
            {
                return new ServiceResponseDto { ISuccess = false, Message = "Project not found" };
            }

            context.Projects.Remove(project);
            await context.SaveChangesAsync();
            return new ServiceResponseDto { ISuccess = true, Message = "Project deleted successfully" };
        }
    }
}
