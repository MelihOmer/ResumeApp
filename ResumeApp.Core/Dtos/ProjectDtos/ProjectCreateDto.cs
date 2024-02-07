using Microsoft.AspNetCore.Http;

namespace ResumeApp.Core.Dtos.ProjectDtos
{
    public class ProjectCreateDto
    {
        public string ProjectName { get; init; } 
        public string ProjectDescription { get; init; }
        public string ProjectPath { get; init; }
        public int ResumeId { get; init; }
        public IFormFile file { get; init; }
       
    }
}
