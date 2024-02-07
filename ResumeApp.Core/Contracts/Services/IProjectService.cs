using Microsoft.AspNetCore.Http;
using ResumeApp.Core.Dtos.ProjectDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface IProjectService : IGenericService<Project>
    {
        Task AddProject(ProjectCreateDto dto, int resumeId);
        Task<byte[]> DownloadProject(string projectName);
        Task<ProjectUpdateDto> GetProjectUpdate(int id);
        Task ProjectUpdate(ProjectUpdateDto dto);
        Task<byte[]> DownloadCV();
        Task SaveCv(IFormFile file);
        Task RemoveProject(int id);
    }
}
