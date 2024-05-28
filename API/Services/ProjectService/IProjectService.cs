using API.Dto;

namespace API.Services.ProjectService
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProjects();
        Task<ProjectDto> GetProjectById(int id);
        Task<ServiceResponseDto> CreateProject(ProjectCreateDto projectDto);
        Task<ServiceResponseDto> UpdateProject(int projectId, ProjectUpdateDto projectDto);
        Task<ServiceResponseDto> DeleteProject(int id);
    }
}
